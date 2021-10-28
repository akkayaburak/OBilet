using OBilet.Models;
using OBilet.Operations;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OBilet.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ResultSessionModel resultSessionModel = await OBiletOperations.GetSession();
            HttpCookie sessionCookie = new HttpCookie("sessionCookie");
            sessionCookie["DeviceId"] = resultSessionModel.Data.DeviceId;
            sessionCookie["SessionId"] = resultSessionModel.Data.SessionId;
            Response.Cookies.Add(sessionCookie);
            ResultBusLocationsModel busLocationsModel = await OBiletOperations.GetBusLocations(resultSessionModel);
            ViewData["BusLocations"] = busLocationsModel;
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> BusJourneys([FromBody] GetBusJourneysModel getBusJourneysModel)
        {
            //HttpClient client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://v2-api.obilet.com/api")
            //};
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
            //HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "https://v2-api.obilet.com/api/journey/getbusjourneys") { Content = new StringContent(JsonConvert.SerializeObject(getBusJourneysModel), Encoding.UTF8, "application/json") };
            //var res = await client.SendAsync(req);
            //string resString = await res.Content.ReadAsStringAsync();
            //ViewData["BusJourneys"] = getBusJourneysModel;
            return Json(new { result = "Redirect", url = Url.Action("ActionName", "Home") });
        }
    }
}
