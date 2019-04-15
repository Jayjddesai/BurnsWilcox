using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class CancelController : Controller
    {
        public ActionResult GetPartialCancel(string policyNumber)
        {
            return PartialView();
        }
    }
}