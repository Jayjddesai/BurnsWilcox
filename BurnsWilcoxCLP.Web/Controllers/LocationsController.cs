using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class LocationsController : Controller
    {
        public ActionResult GetPartialLocations(string policyNumber)
        {
            return PartialView();
        }
    }
}