using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercice1.Models
{
#nullable enable
    class Station
    {

        /// <summary>
        /// Model class to stock the stations form the CSV file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="domainName"></param>
        /// <param name="altitude"></param>
        /// <param name="maxAltitude"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="adultCost"></param>
        /// <param name="childrenCost"></param>
        /// <param name="liftNumber"></param>
        /// <param name="trackNumber"></param>
        /// <param name="trackLenght"></param>
        public Station(string name, string domainName, string canton, int? altitude, int? maxAltitude, float? latitude, float? longitude, int? adultCost, int? childrenCost, int? liftNumber, int? trackNumber, int? trackLenght)
        {
            Name = name;
            DomainName = domainName;
            Canton = canton;
            Altitude = altitude;
            MaxAltitude = maxAltitude;
            Latitude = latitude;
            Longitude = longitude;
            AdultCost = adultCost;
            ChildrenCost = childrenCost;
            LiftNumber = liftNumber;
            TrackNumber = trackNumber;
            TrackLenght = trackLenght;
        }

        //properties - pulic to be ordered by the controller with linQ, select, where....
        public string Name { get; set; }
        public string DomainName { get; set; }
        public string Canton { get; set; }
        public int? Altitude { get; set; }
        public int? MaxAltitude { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int? AdultCost { get; set; }
        public int? ChildrenCost { get; set; }
        public int? LiftNumber { get; set; }
        public int? TrackNumber { get; set; }
        public int? TrackLenght { get; set; }

        public override string ToString()
        {
            //IMPORTANT : tostring from property, taken from https://stackoverflow.com/questions/9299286/dynamic-override-of-tostring-using-reflection
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (System.Reflection.PropertyInfo property in this.GetType().GetProperties())
            {
                sb.Append(property.Name);
                sb.Append(": ");
                if (property.GetIndexParameters().Length > 0)
                {
                    sb.Append("Indexed Property cannot be used");
                }
                else
                {
                    sb.Append(property.GetValue(this, null));
                }
                sb.Append(",");
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
#nullable disable
}
