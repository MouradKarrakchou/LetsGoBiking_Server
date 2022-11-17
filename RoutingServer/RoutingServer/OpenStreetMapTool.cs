using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;


namespace RoutingServer
{
    class OpenStreetMapTool
    {

        string query, url, response, apiKey;
        public GeoLoca GetPositionWithAdress(string adress)
        {
            apiKey = "5b3ce3597851110001cf6248b0f9aba6d4384d7195f01c6be0f71578";
            query = "api_key=" + apiKey;
            query = query + "&" + "text=" + adress;
            url = "https://api.openrouteservice.org/geocode/autocomplete";
            response = GeoCodeApiCall(url, query).Result;
            GeoLoca geoLocalisationDetails = JsonConvert.DeserializeObject<GeoLoca>(response);
            return (geoLocalisationDetails);
        }

        static async Task<string> GeoCodeApiCall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }


    public class GeoLoca
    {
        public List<Feature> features { get; set; }
    }
    public class Feature
    {
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
    public class Geometry
    {
        public List<Double> coordinates { get; set; }
    }
    public class Properties
    {
        public string country { get; set; }
        public string region { get; set; }
    }

}
