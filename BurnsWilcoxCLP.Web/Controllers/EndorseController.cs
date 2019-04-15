using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class EndorseController : Controller
    {
        public ActionResult GetPartialEndorse(string policyNumber)
        {
            return PartialView();
        }
    }
}