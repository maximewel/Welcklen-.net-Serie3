using exercice1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace exercice1.Models
{
    /// <summary>
    /// Class that parse the station file and stock the stations in memory
    /// </summary>
    class StationParser
    {
        //attributes
        private static List<Station> stations = new List<Station>();
        private const int NUMBER_FIELD_STATION = 12;

        //initialize the parser with the station list (CSV : static file)
        public StationParser() {
            //get stations as string, parse them as station
            var allStations = ParseStationsFromString(GetLinesStationFromFile());
            //stock them because the file is static. If it was not, this step would never be done (we would re-parse the file at each query)
            stations.AddRange(allStations);
        }

        /// <summary>
        /// Get the stations from initialisation (Warning : File is not re-read)
        /// </summary>
        /// <returns>The stations</returns>
        public List<Station> GetStations()
        {
            return stations;
        }

        /// <summary>
        /// Read the file as a ressource
        /// </summary>
        /// <returns>The file as an array of string</returns>
        private static String[] GetLinesStationFromFile()
        {
            return Properties.Resources.SwissSkiDB.Split("\n");
        }

        /// <summary>
        /// Parse stations from a list of strings - if a string can ont be parsed, it is skipped
        /// </summary>
        /// <param name="stream">the strings, each string containing a station</param>
        /// <returns>the list of stations</returns>
        private static IEnumerable<Station> ParseStationsFromString(IEnumerable<String> stream)
        {
            foreach (string s in stream)
            {
                String[] datas = s.Split(";");

                if(datas.Length != NUMBER_FIELD_STATION)
                {
                    //we can not parse this line
                    continue;
                }

                //build the list of attributes
                //strings can be empty, "" is not considered null
                string name = datas[0], domainName = datas[1], canton = datas[2];
                //parse int and floats
                int? alt = ParseIntOrNull(datas[3]), maxAlt = ParseIntOrNull(datas[5]);
                float? lat = ParseFloatOrNull(datas[5]), longit = ParseFloatOrNull(datas[6]);
                int? adultCost = ParseIntOrNull(datas[7]), childrenCost = ParseIntOrNull(datas[8]);
                int? liftNumber = ParseIntOrNull(datas[9]), trackNumber = ParseIntOrNull(datas[10]), trackLenght = ParseIntOrNull(datas[11]);

                //assign it to the station
                Station station = new Station(
                    name, domainName, canton,
                    alt, maxAlt,
                    lat, longit,
                    adultCost, childrenCost,
                    liftNumber, trackNumber, trackLenght
                    );
                yield return station;
            }
        }

        /// <summary>
        /// Parse an in to a null or an int
        /// </summary>
        /// <param name="s">the string to parse from</param>
        /// <returns>the int, or null if unable to parse</returns>
        private static int? ParseIntOrNull(string s)
        {
            return int.TryParse(s, out int nb) ? nb : (int?) null;
        }

        /// <summary>
        /// Parse an in to a null or a float
        /// </summary>
        /// <param name="s">the string to parse from</param>
        /// <returns>the float, or null if unable to parse</returns>
        private static float? ParseFloatOrNull(string s)
        {
            return float.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float nb) ? nb : (float?)null;
        }

    }
}
