using Newtonsoft.Json;
using OBilet.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OBilet.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
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
            client.BaseAddress = new Uri("https://v2-api.obilet.com/api");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "https://v2-api.obilet.com/api/client/getsession") { Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json") };

            var res = await client.SendAsync(req);
            string resString = await res.Content.ReadAsStringAsync();
            res.Dispose();
            client.Dispose();


            ResultSessionModel resultSession = JsonConvert.DeserializeObject<ResultSessionModel>(resString);
            GetBusLocationsModel getBusLocations = new GetBusLocationsModel
            {
                DeviceSession = new DeviceSession
                {
                    DeviceId = resultSession.Data.DeviceId,
                    SessionId = resultSession.Data.SessionId
                },
            };

            client = new HttpClient();
            client.BaseAddress = new Uri("https://v2-api.obilet.com/api");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
            req = new HttpRequestMessage(HttpMethod.Post, "https://v2-api.obilet.com/api/location/getbuslocations") { Content = new StringContent(JsonConvert.SerializeObject(getBusLocations), Encoding.UTF8, "application/json") };
            res = await client.SendAsync(req);
            resString = await res.Content.ReadAsStringAsync();
            ResultBusLocationsModel resultBusLocationsModel = JsonConvert.DeserializeObject<ResultBusLocationsModel>(resString);
            ViewData["BusLocations"] = resultBusLocationsModel;
            return View();
        }

    }
}
