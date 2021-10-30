using OBilet.Models;
using OBilet.Operations;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OBilet.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public async Task<ActionResult> Index()
        {
            try
            {
                ResultSessionModel resultSessionModel = await OBiletOperations.GetSession();

                HttpCookie sessionCookie = new HttpCookie("sessionCookie");
                sessionCookie["DeviceId"] = resultSessionModel.Data.DeviceId;
                sessionCookie["SessionId"] = resultSessionModel.Data.SessionId;
                Response.Cookies.Add(sessionCookie);

                ResultBusLocationsModel busLocationsModel = await OBiletOperations.GetBusLocations(resultSessionModel);
                if (busLocationsModel.Data.Count > 1)
                {
                    ViewData["BusLocations"] = busLocationsModel;
                    return View();
                }
                return View("Error");
            } 
            catch(Exception ex)
            {
                ModelState.AddModelError("Index", ex);
                return View("Error");
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getBusJourneysModel"></param>
        /// <returns>All the bus journeys with specified Date, Origin and Destination</returns>
        public async Task<ActionResult> BusJourneys([FromBody] GetBusJourneysModel getBusJourneysModel)
        {
            try
            {
                ResultBusJourneysModel resultBusJourneysModel = await OBiletOperations.GetBusJourneys(getBusJourneysModel);
                if (resultBusJourneysModel.Data.Count > 1)
                {
                    ViewData["BusJourneys"] = resultBusJourneysModel;
                    return View();
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("BusJourneys", ex);
                return View("Error");
            }
            
        }
    }
}
