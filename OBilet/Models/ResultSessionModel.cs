using Newtonsoft.Json;

namespace OBilet.Models
{
    public class ResultSessionModel
    {
        public string Status { get; set; }
        public SessionData Data { get; set; }
        public string Message { get; set; }
        [JsonProperty("user-message")]
        public string UserMessage { get; set; }
        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }
        public string Controller { get; set; }
        [JsonProperty("client-request-id")]
        public string ClientRequestId { get; set; }
    }

    public class SessionData
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
        public string Affiliate { get; set; }
        [JsonProperty("device-type")]
        public int DeviceType { get; set; }
        public string Device { get; set; }
    }
}