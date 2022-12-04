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
using System.Web;

namespace RoutingServer
{
    class OpenStreetMapTool
    {
        string apiKey = "5b3ce3597851110001cf6248b0f9aba6d4384d7195f01c6be0f71578";
        string query, url, response;

        public GeoLoca GetPositionWithAdress(string adress)
        {
            adress = Uri.EscapeUriString(adress);
            query = "api_key=" + apiKey;
            query = query + "&" + "text=" + adress;
            url = "https://api.openrouteservice.org/geocode/search";
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

        public List<Itinary> createItinary(GeoCoordinate geoCoordinate1, GeoCoordinate geoCoordinate2, GeoCoordinate geoCoordinate3, GeoCoordinate geoCoordinate4)
        {
            string urlOnFoot = "https://api.openrouteservice.org/v2/directions/foot-walking/geojson";

            List<Itinary> itinaries = GenerateItinaries(geoCoordinate1, geoCoordinate2, geoCoordinate3, geoCoordinate4);

            Itinary straightItinary = GetItinaryFrom2Point(geoCoordinate1, geoCoordinate4, urlOnFoot, true);
            Itinary completeItinary = new Itinary();

            foreach (Itinary itinary in itinaries)
            {
                completeItinary.addItinary(itinary);
            }

            if (completeItinary.calculateDuration() <= straightItinary.calculateDuration()) return itinaries;
            else return new List<Itinary>() { straightItinary };
        }

        public List<Itinary> GenerateItinaries(GeoCoordinate geoCoordinate1, GeoCoordinate geoCoordinate2, GeoCoordinate geoCoordinate3, GeoCoordinate geoCoordinate4)
        {
            string urlOnBycicle = "https://api.openrouteservice.org/v2/directions/cycling-regular/geojson";
            string urlOnFoot = "https://api.openrouteservice.org/v2/directions/foot-walking/geojson";

            List<Itinary> itinaries = new List<Itinary>();
            itinaries.Add(GetItinaryFrom2Point(geoCoordinate1, geoCoordinate2, urlOnFoot, true));
            itinaries.Add(GetItinaryFrom2Point(geoCoordinate2, geoCoordinate3, urlOnBycicle, false));
            itinaries.Add(GetItinaryFrom2Point(geoCoordinate3, geoCoordinate4, urlOnFoot, true));


            return (itinaries);
        }
        public Itinary GetItinaryFrom2Point(GeoCoordinate geoCoordinate1,GeoCoordinate geoCoordinate2, string url, Boolean onFoot)
        {
            query = "api_key=" + apiKey;
            //POST REQUEST
            Geojson geojson = new Geojson();
            List<Task<string>> results = new List<Task<string>>();
            geojson.addCoordonate(geoCoordinate1);
            geojson.addCoordonate(geoCoordinate2);
            string postBody = JsonConvert.SerializeObject(geojson);
            Task<String> result=DirectionsServicePOST(url, query, new StringContent(postBody, Encoding.UTF8, "application/json"));
            string jsonResult = result.Result;
            Itinary itinary = JsonConvert.DeserializeObject<Itinary>(jsonResult);
            itinary.onFoot = onFoot;
            return itinary;
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
            double latitude = features[0].geometry.coordinates[1];
            double longitude = features[0].geometry.coordinates[0];
            return new GeoCoordinate(latitude,longitude);
        }
        internal string getCity()
        {
            return features[0].properties.locality;
        }
    }

    public class Itinary
    {
        public Boolean onFoot { get; set; }

        public List<FeatureItinary> features { get; set; }
        public Itinary()
        {
            features = new List<FeatureItinary>();
        } 
        public void addItinary(Itinary itinary)
        {
            this.features.AddRange(itinary.features);
        }

        public double calculateDuration()
        {
            double time = 0;
            foreach(FeatureItinary feature in features)
            {
                time += feature.calculateDuration();
            }
            return (time);
        }
    }

    public class FeatureItinary
    {
        public GeometryItinary geometry { get; set; }
        public Properties properties { get; set; }
        public double calculateDuration()
        {
            return (properties.calculateDuration());
        }
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

        public double calculateDuration()
        {
            double time = 0;
            foreach (Segment segment in segments)
            {
                time += segment.duration;
            }
            return (time);
        }

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

