using System;
using System.Web.Mvc;
using BurnsWilcoxCLP.Models.Common;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class PolicyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}