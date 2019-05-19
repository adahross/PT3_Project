using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMvcWebApp.Controllers
{
    [Authorize(Roles = "ShipmentAgent")]
    public class ShipmentAgentController : Controller
    {
        
        // GET: ShipmentAgent
        public ActionResult DoShipment()
        {
            return View();
        }
    }
}