using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using Newtonsoft.Json;
using RoutingServer.ServiceReference1;


namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Bike : IBikeService
    {

        JcdecauxTool jcdecauxTool = new JcdecauxTool();
        OpenStreetMapTool openStreetMapTool = new OpenStreetMapTool();
        Producer producer = new Producer();

        List<Itinary> userItinary = new List<Itinary>();
        JCDStation userDestinationStation;
        JCDStation userOriginStation;      
        GeoLoca userDestinationGeoLoca;

        /// <summary>
        /// Return the 3 itinary of that compose the whole route of the user, origin -> firstBikeStation -> secondBikeStation -> destination
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="cityName"></param>
        /// <returns> Return the 3 itinary,{[origin -> firstBikeStation],[firstBikeStation-> secondBikeStation],[secondBikeStation -> destination]}</returns>
        public List<Itinary> GetItinerary(string origin, string destination, string cityName)
        {
            return  calculateItinerary(origin, destination, cityName);
        }

        /// <summary>
        /// return a dataContainer that contain the current part of the global itinary and a string texte of an exception
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="cityName"></param>
        /// <returns>a DataContainer with the current part of the itinary</returns>
        public ActiveMqResponse GetDataContainer(String origin, String destination, string cityName)
        {
            ActiveMqResponse data = new ActiveMqResponse();
            try
            {
                data.itinary = GetItinerary(origin, destination, cityName)[0];
            }
            catch (Exception e)
            {
                data.exception = e.Message;
            }
            return data;
        }
        /// <summary>
        /// Put the DataContainer inside activemq queue of the user
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="cityName"></param>
        /// <param name="username"></param>
        public void PutDataContainerInQueue(String origin, String destination, string cityName, string username)
        {
            ActiveMqResponse data = GetDataContainer(origin, destination, cityName);
            StringWriter strWriter = new StringWriter();
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(strWriter, data);
            producer.setupProducer(username);
            producer.sendMessage(strWriter.ToString());
        }
        /// <summary>
        /// Return the entire itinary using origin and destination.
        /// If the parameter cityName is define the itinary will be based on this cityname
        /// If it is define to "" the programme 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="cityName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private List<Itinary> calculateItinerary(String origin, String destination, string cityName)
        {
            GeoLoca originGeoLoca = openStreetMapTool.GetPositionWithAdress(origin);
            GeoLoca destinationGeoLoca = openStreetMapTool.GetPositionWithAdress(destination);

            if (cityName == "") cityName = originGeoLoca.getCity();


            List<JCDStation> stationsOfContract = jcdecauxTool.getStationsUsingCity(originGeoLoca.getCity());

            JCDStation originStation = GetNearestStation(originGeoLoca, stationsOfContract, true, false);
            JCDStation destinationStation = GetNearestStation(destinationGeoLoca, stationsOfContract, false, true);

            if (originStation==null || destinationStation == null) throw new Exception("No station found");
            if (originStation.contractName != destinationStation.contractName) throw new Exception("The two station choosen are not in the same contract");

            userOriginStation = originStation;
            userDestinationStation = destinationStation;
            userDestinationGeoLoca = destinationGeoLoca;

            userItinary = CreateItinary(originGeoLoca, originStation, destinationStation, destinationGeoLoca);
            return userItinary;
        }

        public List<Itinary> CreateItinary(GeoLoca originGeoLoca, JCDStation originStation, JCDStation destinationStation, GeoLoca destinationGeoLoca)
        {

            return openStreetMapTool.createItinary(originGeoLoca.getGeoCoord(), getGeoCoord(originStation), getGeoCoord(destinationStation), destinationGeoLoca.getGeoCoord());
        }
        internal GeoCoordinate getGeoCoord(JCDStation station)
        {
            return new GeoCoordinate(station.position.latitude, station.position.longitude);
        }

        public JCDStation GetNearestStation(GeoLoca coord, List<JCDStation> stations, Boolean takeABike, Boolean leaveABike)
        {
            if (coord.getCity() == null) throw new Exception("No locality in the features, causes of other sources than openstreet-route");
            return jcdecauxTool.GetNearestStation(coord.getGeoCoord(), stations, takeABike, leaveABike);
        }

        public void update() {
            if (userItinary.Count == 0) return;
            userItinary.Remove(userItinary[0]);
            List<JCDStation> stationsOfContract = jcdecauxTool.getStations(userDestinationStation.contractName);
            if (userItinary[0].onFoot == false && needUpdate(stationsOfContract)) {
                updateItinary(stationsOfContract);
            }
            addItinaryToTheQueue();
        }


        private bool needUpdate(List<JCDStation> stationsOfContract)
        {
            JCDStation endStation = jcdecauxTool.getStationUsingStation(userDestinationStation, stationsOfContract);
            if (endStation == null) throw new Exception("No station with destinationStationName found");
            if (endStation.mainStands.availabilities.stands >= JcdecauxTool.nbMinOfStand) return false;
            return true;
        }

        public void updateItinary(List<JCDStation> stationsOfContract) {
            JCDStation destinationStation = GetNearestStation(userDestinationGeoLoca, stationsOfContract, false, true);
            if (destinationStation == null) throw new Exception("No station found");
            Itinary bicycleItinary = openStreetMapTool.GetItinaryFrom2Point(getGeoCoord(userOriginStation), getGeoCoord(destinationStation), OpenStreetMapTool.urlOnBycicle,false);
            Itinary footItinary = openStreetMapTool.GetItinaryFrom2Point(getGeoCoord(destinationStation), userDestinationGeoLoca.getGeoCoord(), OpenStreetMapTool.urlOnFoot, true);
            this.userItinary = new List<Itinary> { bicycleItinary , footItinary };
        }

        private void addItinaryToTheQueue()
        {
            //TODO FAIRE EN SORTE QUE ActiveMqResponse NE CONTIENNE QU'UN SEUL ITINARY
            ActiveMqResponse data = new ActiveMqResponse();
            StringWriter strWriter = new StringWriter();
            JsonSerializer jsonSerializer = new JsonSerializer();
            data.itinary = userItinary[0];
            jsonSerializer.Serialize(strWriter, data);
            producer.sendMessage(strWriter.ToString());
        }

        
    }
}
