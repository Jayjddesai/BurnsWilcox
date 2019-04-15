using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class QuoteController : Controller
    {
        public ActionResult GetPartialQuote(string policyNumber)
        {
            if(ModelState.IsValid)
            {

            }
            return PartialView();
        }
    }
}