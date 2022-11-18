using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoCoordinate = System.Device.Location.GeoCoordinate;


namespace RoutingServer
{
    internal class Main1
    {
       
        static void Main(string[] args)
        {
            OpenStreetMapTool tool = new OpenStreetMapTool();
            GeoCoordinate a = new GeoCoordinate(8.681495, 49.41461);
            GeoCoordinate b = new GeoCoordinate(8.686507, 49.41943);
            GeoCoordinate c = new GeoCoordinate(8.687872, 49.420318);
            GeoCoordinate d = new GeoCoordinate(8.687872, 49.450318);
            tool.createItinary(a, b, c, d);
        }
    }
}
