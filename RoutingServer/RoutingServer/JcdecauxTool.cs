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
using RoutingServer.ServiceReference1;
//
namespace RoutingServer
{
    internal class JcdecauxTool
    {
        public string apiKey= "3aff999b9fe29460c5a8b1a3ca8d551d5a60eda7";
        string query, url, response;

        public JcdecauxTool()
        {
        }

        private List<JCDStation> getAllStations()
        {
            List<JCDContract> contracts = getAllContracts();
            List<JCDStation> stations = new List<JCDStation>();

            for(int i = 0; i < contracts.Count; i++) {
                string s = contracts[i].name;
                stations.AddRange(getStations(s));
            }
            return stations;
        }

      

        public List<JCDContract> getAllContracts()
        {
            ProxyClient proxyClient = new ProxyClient();
            JCDContract[] jCDContracts = proxyClient.getAllContracts();
            return (jCDContracts.ToList()) ;
        }
        public List<JCDStation> getStations(string contract)
        {
            ProxyClient proxyClient = new ProxyClient();
            JCDStation[] jCDStations = proxyClient.getStations(contract);
            return (jCDStations.ToList());
        }
        public JCDStation retrieveOneStation(int stationNumber, List<JCDStation> allStations)
        {
            JCDStation chosenStation = allStations[0];
            foreach (JCDStation item in allStations)
            {
                if (item.number == stationNumber)
                {
                    chosenStation = item;
                    break;
                }
            }
            return chosenStation;
        }
        public JCDStation GetNearestStation(GeoCoordinate stationCoordinates, List<JCDStation> stations)
        {
            JCDStation closestStation = stations[0];
            GeoCoordinate candidatePos = new GeoCoordinate(closestStation.position.latitude, closestStation.position.longitude);

            Double minDistance = stationCoordinates.GetDistanceTo(candidatePos);

            foreach (JCDStation item in stations)
            {
                // Find the current station's position.
                candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                // And compare its distance to the chosen one to see if it is closer than the current closest.
                Double distanceToCandidate = stationCoordinates.GetDistanceTo(candidatePos);

                if (distanceToCandidate != 0 && distanceToCandidate < minDistance)
                {
                    closestStation = item;
                    minDistance = distanceToCandidate;
                }
            }
            return closestStation;
        }

        public JCDStation closestStationFromStation(JCDStation chosenStation, List<JCDStation> allStations)
        {
            Double minDistance = -1;
            JCDStation closestStation = chosenStation;
            GeoCoordinate stationCoordinates = new GeoCoordinate(chosenStation.position.latitude, chosenStation.position.longitude);
            foreach (JCDStation item in allStations)
            {
                // Find the current station's position.
                GeoCoordinate candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                // And compare its distance to the chosen one to see if it is closer than the current closest.
                Double distanceToCandidate = stationCoordinates.GetDistanceTo(candidatePos);

                if (distanceToCandidate != 0 && (minDistance == -1 || distanceToCandidate < minDistance))
                {
                    closestStation = item;
                    minDistance = distanceToCandidate;
                }
            }
            return (closestStation);
        }
        public JCDStation GetNearestStation(GeoCoordinate coord, string cityName)
        {
            return GetNearestStation(coord, getStations(cityName));
        }

        static string JCDecauxAPICall(string url, string query)
        {
            return (url + "?" + query);
        }
       
    }
}