using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBilet.Models
{
    public class ResultBusLocationsModel
    {
        public string Status { get; set; }
        public List<BusLocationsData> Data { get; set; }

    }
    public class BusLocationsData
    {
        public int Id { get; set; }
        [JsonProperty("parent-id")]
        public int ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }
        public int Zoom { get; set; }
        [JsonProperty("tz-code")]
        public string TzCode { get; set; }
        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }
        public int? Rank { get; set; }
        [JsonProperty("reference-code")]
        public string ReferenceCode { get; set; }
        public string Keywords { get; set; }
    }

    public class GeoLocation
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Zoom { get; set; }
    }
}