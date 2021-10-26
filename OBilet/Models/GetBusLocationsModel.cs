using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBilet.Models
{
    public class GetBusLocationsModel
    {
        public object Data { get; } = null;
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        public DateTime Date { get; } = DateTime.Parse("2019-01-25T11:33:00");
        public string Language { get; } = "en-EN";
    }

    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}