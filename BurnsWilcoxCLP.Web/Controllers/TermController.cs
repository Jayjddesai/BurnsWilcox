using BurnsWilcoxCLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BurnsWilcoxCLP.Models;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class TermController : Controller
    {
        public ActionResult GetPartialTerm(string policyNumber)
        {
        //    ViewBag.TermList = TermEntity.GetTermInMonthsList();
            return PartialView();
        }
    }
}