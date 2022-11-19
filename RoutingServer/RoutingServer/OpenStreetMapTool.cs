using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Device.Location;
using Nest;
using GeoCoordinate = System.Device.Location.GeoCoordinate;
using Newtonsoft.Json.Linq;

namespace RoutingServer
{
    class OpenStreetMapTool
    {
        string apiKey = "5b3ce3597851110001cf6248b0f9aba6d4384d7195f01c6be0f71578";
        string query, url, response;

        public GeoLoca GetPositionWithAdress(string adress)
        {
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

        public void createItinary(GeoCoordinate geoCoordinate1, GeoCoordinate geoCoordinate2, GeoCoordinate geoCoordinate3, GeoCoordinate geoCoordinate4)
        {
            string url = "https://api.openrouteservice.org/v2/directions/driving-car/geojson";
            query = "api_key=" + apiKey;
            //POST REQUEST
            Geojson geojson = new Geojson();
            geojson.addCoordonate(geoCoordinate1);
            geojson.addCoordonate(geoCoordinate2);
            geojson.addCoordonate(geoCoordinate3);
            geojson.addCoordonate(geoCoordinate4);
            string postBody = JsonConvert.SerializeObject(geojson);
            Console.WriteLine(postBody);
            
            Task<string>  result = DirectionsServicePOST(url, query, new StringContent(postBody, Encoding.UTF8, "application/json"));
            string jsonResult = result.Result;
            Console.WriteLine(jsonResult);
            Itinary itinary = JsonConvert.DeserializeObject<Itinary>(jsonResult);

            Console.WriteLine(itinary);

        }

        static async Task<string> DirectionsServicePOST(string url, string query, HttpContent body)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url + "?" + query, body);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }


    public class GeoLoca
    {
        public List<Feature> features { get; set; }

        internal GeoCoordinate getGeoCoord()
        {
            double x = features[0].geometry.coordinates[0];
            double y = features[0].geometry.coordinates[1];
            return new GeoCoordinate(x, y);
        }
        internal string getCity()
        {
            return features[0].properties.locality;
        }
    }

    public class Itinary
    {
        public List<FeatureItinary> features { get; set; }
    }

    public class FeatureItinary
    {
        public GeometryItinary geometry { get; set; }
        public Properties properties { get; set; }
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
    public class GeometryItinary
    {
        public List<List<Double>> coordinates { get; set; }
    }
    public class Properties
    {
        public string country { get; set; }
        public string locality { get; set; }
        public List<Segment> segments { get; set; }

    }
    public class Segment
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public List<Step> steps { get; set; }
    }
    public class Step
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public int type { get; set; }
        public string instruction { get; set; }
        public string name { get; set; }
        public List<int> way_points { get; set; }
    }
    public class Summary
    {
        public double distance { get; set; }
        public double duration { get; set; }
    }
    public class Geojson
    {
        public List<double[]> coordinates = new List<double[]>();
        public void addCoordonate(GeoCoordinate coordonate)
        {
            double[] coord = new double[] { coordonate.Longitude, coordonate.Latitude };
            coordinates.Add(coord);
        }
    }
}

