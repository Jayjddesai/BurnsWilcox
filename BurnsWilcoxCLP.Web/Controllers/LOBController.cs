using System.Reflection;
using System.Web.Mvc;
using BurnsWilcoxCLP.API.API;
using BurnsWilcoxCLP.Models;
using log4net;

// ReSharper disable InconsistentNaming

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class LOBController : Controller
    {
        private readonly LOBAPIController _lobApi;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LOBController()
        {
            _lobApi = new LOBAPIController();
        }

        public ActionResult GetPartialLOB(string policyNumber)
        {
            ViewBag.LOBList = LOBEntity.GetLOBList();
            ViewBag.ProductList = LOBEntity.GetProductList();
            ViewBag.StateList = LOBEntity.GetStateList();

            return PartialView(new LOBEntity());
        }

        public ActionResult SavePolicyLOB(LOBEntity model)
        {
            //var result = _lobApi.SavePolicyLOB(model);
            //return Json(new { success = result.Success, message = result.Message[0] }, JsonRequestBehavior.AllowGet);
            return Json(new { success = true,message = "Saved successfully." }, JsonRequestBehavior.AllowGet);
        }
    }
}