using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Apache.NMS.ActiveMQ.Commands;
using Newtonsoft.Json;
using RoutingServer.ServiceReference1;


namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Bike : IBikeService
    {

        JcdecauxTool jcdecauxTool = new JcdecauxTool();
        OpenStreetMapTool openStreetMapTool = new OpenStreetMapTool();
        Producer producer = new Producer();

        public Itinary GetItinerary(string origin, string destination)
        {
            return calculateItinerary(origin, destination);
        }

        public DataContainer GetDataContainer(String origin, String destination)
        {
            DataContainer data = new DataContainer();
            try
            {
                Itinary itinary = GetItinerary(origin, destination);
                data.itinary = itinary;
            }
            catch (Exception e)
            {
                data.exception = e.Message;
            }
            return data;
        }
        public void PutDataContainerInQueue(String origin, String destination)
        {
            DataContainer data = GetDataContainer(origin, destination);
            StringWriter strWriter = new StringWriter();
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(strWriter, data);
            producer.sendMessage(strWriter.ToString());
        }

        private Itinary calculateItinerary(String origin, String destination)
        {
            GeoLoca originGeoLoca = openStreetMapTool.GetPositionWithAdress(origin);
            GeoLoca destinationGeoLoca = openStreetMapTool.GetPositionWithAdress(destination);

            JCDStation originStation = GetNearestStation(originGeoLoca, true, false);
            JCDStation destinationStation = GetNearestStation(destinationGeoLoca, false, true);

            if (originStation==null || destinationStation == null) throw new Exception("No station found");
            if (originStation.contractName != destinationStation.contractName) throw new Exception("The two station choosen are not in the same contract");
            return CreateItinary(originGeoLoca, originStation, destinationStation, destinationGeoLoca);
        }
        
        public Itinary CreateItinary(GeoLoca originGeoLoca, JCDStation originStation, JCDStation destinationStation, GeoLoca destinationGeoLoca)
        {

            return openStreetMapTool.createItinary(originGeoLoca.getGeoCoord(), getGeoCoord(originStation), getGeoCoord(destinationStation), destinationGeoLoca.getGeoCoord());
        }
        internal GeoCoordinate getGeoCoord(JCDStation station)
        {
            return new GeoCoordinate(station.position.latitude, station.position.longitude);
        }

        public JCDStation GetNearestStation(GeoLoca coord, Boolean takeABike, Boolean leaveABike)
        {
            List<JCDStation> list = new List<JCDStation>();
            if (coord.getCity() == null) throw new Exception("No locality in the features, causes of other sources than openstreet-route");
            return jcdecauxTool.GetNearestStation(coord.getGeoCoord(), coord.getCity(), takeABike, leaveABike);
        }


    }
}
