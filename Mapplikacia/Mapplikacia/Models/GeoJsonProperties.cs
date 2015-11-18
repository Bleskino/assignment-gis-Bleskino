using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Web.Models
{
    public class GeoJsonProperties
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        private string _amenity = string.Empty;

        public string amenity
        {
            get { return _amenity; }
            set { _amenity = value ?? string.Empty; }
        }

        [JsonProperty("marker-symbol")]
        public string MarkerSymbol { get; set; }
        [JsonProperty("marker-color")]
        public string MarkerColor { get; set; }
       
        private string _markerSize = "small";

        [JsonProperty("marker-size")]
        public string MarkerSize
        {
            get { return _markerSize; }
            set { _markerSize = value; }
        }
    }
}