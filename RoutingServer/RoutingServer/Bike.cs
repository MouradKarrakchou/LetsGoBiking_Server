﻿using System;
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

        public string GetItinerary(String origin, String destination)
        {
            return openStreetMapTool.GetItinerary(origin, destination);
        }
        public string GetNearestStation(GeoCoordinate coord)
        {
            return jcdecauxTool.GetNearestStation(coord);
        }
        public string createItinary(String origin, String station1, String station2, String destination)
        {
            return openStreetMapTool.GetItinerary(origin, destination);
        }
    }
}