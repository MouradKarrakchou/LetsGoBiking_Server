using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Bike : IBikeService
    {

        JcdecauxTool jcdecauxTool = new JcdecauxTool();
        OpenStreetMapTool openStreetMapTool = new OpenStreetMapTool();

        public Itinary GetItinerary(String origin, String destination)
        {
            GeoLoca originGeoLoca = openStreetMapTool.GetPositionWithAdress(origin);
            GeoLoca destinationGeoLoca = openStreetMapTool.GetPositionWithAdress(destination);

            JCDStation originStation = GetNearestStation(originGeoLoca);
            JCDStation destinationStation = GetNearestStation(destinationGeoLoca);

            return CreateItinary(originGeoLoca, originStation, destinationStation, destinationGeoLoca);
        }

        public Itinary CreateItinary(GeoLoca originGeoLoca, JCDStation originStation, JCDStation destinationStation, GeoLoca destinationGeoLoca)
        {

            return openStreetMapTool.createItinary(originGeoLoca.getGeoCoord(), originStation.getGeoCoord(), destinationStation.getGeoCoord(), destinationGeoLoca.getGeoCoord());
        }

        public JCDStation GetNearestStation(GeoLoca coord)
        {
            List<JCDStation> list = new List<JCDStation>();
            return jcdecauxTool.GetNearestStation(coord.getGeoCoord(), coord.getCity());
        }

    }
}
