using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OBilet.Models
{
    public class ResultBusJourneysModel
    {
        public string Status { get; set; }
        public List<BusJourneysData> Data { get; set; }
    }

    public class BusJourneysData
    {
        public long Id { get; set; }
        [JsonProperty("partner-id")]
        public int PartnerId { get; set; }
        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }
        public Journey Journey { get; set; }
        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }
        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

    }
    public class Journey
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        [JsonProperty("internet-price")]
        public float InternetPrice { get; set; }
        
    }
}