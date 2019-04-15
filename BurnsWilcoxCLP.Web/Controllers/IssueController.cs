using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class IssueController : Controller
    {
        public ActionResult GetPartialIssue(string policyNumber)
        {
            return PartialView();
        }
    }
}