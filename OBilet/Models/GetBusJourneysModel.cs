using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBilet.Models
{
    public class GetBusJourneysModel
    {
        //[JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        public string Date { get; set; }
        public string Language { get; set; } = "en-EN";
        public GetBusJourneysData Data { get; set; }
    }

    public class GetBusJourneysData
    {
        //[JsonProperty("origin-id")]
        public int OriginId { get; set; }
        //[JsonProperty("destination-id")]
        public int DestinationId { get; set; }
        //[JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}