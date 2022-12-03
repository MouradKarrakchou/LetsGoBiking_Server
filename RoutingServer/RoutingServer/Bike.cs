using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoutingServer.ServiceReference1;


namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Bike : IBikeService
    {

        JcdecauxTool jcdecauxTool = new JcdecauxTool();
        OpenStreetMapTool openStreetMapTool = new OpenStreetMapTool();

        public Itinary GetItinerary(String origin, String destination)
        {
            try
            {
                return calculateItinerary(origin, destination);
            }
            catch (NoContractFoundException e) {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public void putItineraryInQueue(String origin, String destination)
        {
            Itinary itinary = calculateItinerary(origin, destination);
        }

        private Itinary calculateItinerary(String origin, String destination)
        {
            GeoLoca originGeoLoca = openStreetMapTool.GetPositionWithAdress(origin);
            GeoLoca destinationGeoLoca = openStreetMapTool.GetPositionWithAdress(destination);

            JCDStation originStation = GetNearestStation(originGeoLoca, true, false);
            JCDStation destinationStation = GetNearestStation(destinationGeoLoca, false, true);

            if (originStation==null || destinationStation == null) throw new Exception("No stations found");
            if (originStation.contractName != destinationStation.contractName) throw new Exception("The originStation and the destinationStation are not under the same contract");
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
