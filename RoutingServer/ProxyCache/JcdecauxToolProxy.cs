using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// HttpClient is in the System.web.Http namespace.
using System.Net.Http;
// To use JsonSerializer, you need to add System.Text.Json. Depending on your project type and version, you may find it as assembly reference or Nuget package
// (right-click on the project --> (add --> Reference) or Manage NuGet packages).
// GeoCordinates is in the System.Device.Location namespace, coming from System.Device which is an assembly reference.
using System.Device.Location;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
//
namespace ProxyCache
{
    internal class JcdecauxToolProxy
    {
        public string apiKey = "3aff999b9fe29460c5a8b1a3ca8d551d5a60eda7";
        string query, url, response;

        public JcdecauxToolProxy()
        {
        }



        public List<JCDContract> getAllContracts()
        {
            query = "apiKey=" + apiKey;
            url = "https://api.jcdecaux.com/vls/v3/contracts";
            string request = JCDecauxAPICall(url, query);
            GenericProxyCache<List<JCDContract>> genericProxyCache = new GenericProxyCache<List<JCDContract>>();
            List<JCDContract> allContracts = genericProxyCache.Get(request);
            return (allContracts);
        }
        public List<JCDStation> getStations(string contract)
        {
            url = "https://api.jcdecaux.com/vls/v3/stations";
            query = "contract=" + contract + "&apiKey=" + apiKey;
            string request = JCDecauxAPICall(url, query);
            GenericProxyCache<List<JCDStation>> genericProxyCache= new GenericProxyCache<List<JCDStation>>();
            List < JCDStation > allStations = genericProxyCache.Get(request);
            return (allStations);
        }

        static string JCDecauxAPICall(string url, string query)
        {
            return (url + "?" + query);
        }

    }

    public class JCDContract
    {
        public string name { get; set; }
    }

    public class JCDStation
    {
        public int number { get; set; }
        public string name { get; set; }
        public Position position { get; set; }

        internal GeoCoordinate getGeoCoord()
        {
            return new GeoCoordinate(position.latitude, position.longitude);
        }
    }

    public class Position
    {
        public Double latitude { get; set; }
        public Double longitude { get; set; }
    }
}