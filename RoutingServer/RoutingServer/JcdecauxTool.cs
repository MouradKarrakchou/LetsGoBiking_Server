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
using System.Diagnostics.Contracts;
//
namespace RoutingServer
{
    internal class JcdecauxTool
    {
        public string apiKey= "3aff999b9fe29460c5a8b1a3ca8d551d5a60eda7";
        string query, url, response;
        ProxyClient proxyClient = new ProxyClient();
        public static int nbMinOfBike = 1;
        public static int nbMinOfStand = 1;

        public JcdecauxTool()
        {
        }

        /// <summary>
        /// return all station of a contract
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public List<JCDStation> getStations(string contract)
        {
            JCDStation[] jCDStations = proxyClient.getStations(contract);
            return (jCDStations.ToList());
        }

        /// <summary>
        /// Return the nearest station of the coord using a list of station
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="stations"></param>
        /// <returns></returns>
        public JCDStation GetNearestStation(GeoCoordinate coord, List<JCDStation> stations)
        {
            JCDStation closestStation = stations[0];
            GeoCoordinate candidatePos = new GeoCoordinate(closestStation.position.latitude, closestStation.position.longitude);

            Double minDistance = coord.GetDistanceTo(candidatePos);

            foreach (JCDStation item in stations)
            {
                // Find the current station's position.
                candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                // And compare its distance to the chosen one to see if it is closer than the current closest.
                Double distanceToCandidate = coord.GetDistanceTo(candidatePos);

                if (distanceToCandidate != 0 && distanceToCandidate < minDistance)
                {
                    closestStation = item;
                    minDistance = distanceToCandidate;
                }
            }
            return closestStation;
        }

        /// <summary>
        /// Return the nearest station of the coord using a list of station, check if there are some bike/place to leave a bike
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="stations"></param>
        /// <param name="takeABike"></param>
        /// <param name="leaveABike"></param>
        /// <returns></returns>
        public JCDStation GetNearestStation(GeoCoordinate coord, List<JCDStation> stations, Boolean takeABike, Boolean leaveABike)
        {
            if (takeABike) {
                stations = removeStationWithNoBike(stations);
            }
            if (leaveABike)
            {
                stations = removeStationWithNoStand(stations);
            }
            if (stations.Count == 0) return null;
            return GetNearestStation(coord, stations);
        }
        /// <summary>
        /// Remove all station with not enought stand
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        private List<JCDStation> removeStationWithNoStand(List<JCDStation> stations)
        {
            List<JCDStation> stationsWithStand = new List<JCDStation>();
            foreach (JCDStation station in stations)
            {
                if (station.mainStands.availabilities.stands > nbMinOfStand)
                    stationsWithStand.Add(station);
            }
            return stationsWithStand;
        }
        /// <summary>
        /// Remove all station with not enought bike
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        private List<JCDStation> removeStationWithNoBike(List<JCDStation> stations)
        {
            List<JCDStation>  stationsWithBike = new List<JCDStation>();
            foreach (JCDStation station in stations) { 
                if(station.mainStands.availabilities.bikes >= nbMinOfBike)
                    stationsWithBike.Add(station);
            }
            return stationsWithBike;
        }
        /// <summary>
        /// Return the contract matching with a city name
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public JCDContract getContractsOfCity(string cityName)
        {
           return proxyClient.getContract(cityName);
        }

        /// <summary>
        /// return all the station using a name of a city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public  List<JCDStation> getStationsUsingCity(String city)
        {
            JCDContract contract = getContractsOfCity(city);
            if (contract == null) throw new Exception("No contract found");
            return getStations(contract.name);
        }
        /// <summary>
        /// return the search inside a list of station a station
        /// </summary>
        /// <param name="destinationStation"></param>
        /// <param name="stations"></param>
        /// <returns></returns>
        internal JCDStation getStationUsingStation(JCDStation destinationStation, List<JCDStation> stations)
        {
            foreach (JCDStation station in stations) { 
                if(station.name == destinationStation.name) return station;
            }
            return null;
        }
    }
}