﻿using OBilet.Models;
using OBilet.Operations;
using System;
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
            try
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
            catch(Exception ex)
            {
                ModelState.AddModelError("Index", ex);
                return View();
            }
            
        }

        public async Task<ActionResult> BusJourneys([FromBody] GetBusJourneysModel getBusJourneysModel)
        {
            try
            {
                ResultBusJourneysModel resultBusJourneysModel = await OBiletOperations.GetBusJourneys(getBusJourneysModel);
                ViewData["BusJourneys"] = resultBusJourneysModel;
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("BusJourneys", ex);
                return View();
            }
            
        }
    }
}
