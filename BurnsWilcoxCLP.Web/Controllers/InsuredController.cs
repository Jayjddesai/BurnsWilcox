using BurnsWilcoxCLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class InsuredController : Controller
    {
        public ActionResult GetPartialInsured(string policyNumber)
        {           
            ViewBag.TitleList = InsuredEntity.GetTitleList();
            ViewBag.InsuredTypeList = InsuredEntity.GetInsuredTypeList();
            ViewBag.SuffixList=InsuredEntity.GetSuffixList();
            ViewBag.LEList=InsuredEntity.GetLEList();
            return PartialView();
        }
        public ActionResult SavePolicyInsured(InsuredEntity model)
        {
            if(ModelState.IsValid)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Save Successfully');</script>");
            }
            return View();
        }
    }
}