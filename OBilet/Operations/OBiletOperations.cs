using Newtonsoft.Json;
using OBilet.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OBilet.Operations
{
    public class OBiletOperations
    {
        private static readonly string Token = "JEcYcEMyantZV095WVc3G2JtVjNZbWx1";
        public static async Task<ResultSessionModel> GetSession()
        {
            var client = new HttpClient();
            GetSessionModel model = new GetSessionModel
            {
                Type = 7,
                Connection = new Connection
                {
                    IpAddress = "78.173.70.56",
                    Port = "5117"
                },
                Browser = new Browser
                {
                    Name = "Chrome",
                    Version = "47.0.0.12"
                }
            };
            client.BaseAddress = new Uri(Helpers.UrlHelper.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Token);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, Helpers.UrlHelper.SessionUrl) { Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json") };

            var res = await client.SendAsync(req);
            string resString = await res.Content.ReadAsStringAsync();
            res.Dispose();
            client.Dispose();

            return JsonConvert.DeserializeObject<ResultSessionModel>(resString);
        }

        public static async Task<ResultBusLocationsModel> GetBusLocations(ResultSessionModel resultSessionModel)
        {
            GetBusLocationsModel getBusLocations = new GetBusLocationsModel
            {
                DeviceSession = new DeviceSession
                {
                    DeviceId = resultSessionModel.Data.DeviceId,
                    SessionId = resultSessionModel.Data.SessionId
                },
            };

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Helpers.UrlHelper.BaseUrl)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Token);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, Helpers.UrlHelper.BusLocationsUrl) { Content = new StringContent(JsonConvert.SerializeObject(getBusLocations), Encoding.UTF8, "application/json") };
            var res = await client.SendAsync(req);
            string resString = await res.Content.ReadAsStringAsync();
            res.Dispose();
            client.Dispose();
            return JsonConvert.DeserializeObject<ResultBusLocationsModel>(resString);
        }
        public static async Task<ResultBusJourneysModel> GetBusJourneys(GetBusJourneysModel getBusJourneysModel)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Helpers.UrlHelper.BaseUrl)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Token);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, Helpers.UrlHelper.BusJourneysUrl) { Content = new StringContent(JsonConvert.SerializeObject(getBusJourneysModel), Encoding.UTF8, "application/json") };
            var res = await client.SendAsync(req);
            string resString = await res.Content.ReadAsStringAsync();
            res.Dispose();
            client.Dispose();

            ResultBusJourneysModel result = JsonConvert.DeserializeObject<ResultBusJourneysModel>(resString);
            result.Data = result.Data.OrderBy(x => x.Journey.DepartureDateForOrder).ToList();
            return result;
        }

    }
}