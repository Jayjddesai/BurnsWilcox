using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class RenewController : Controller
    {
        public ActionResult GetPartialRenew(string policyNumber)
        {
            return PartialView();
        }
    }
}