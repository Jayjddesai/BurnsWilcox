using BurnsWilcoxCLP.API.API;
using BurnsWilcoxCLP.Models;
using Kendo.Mvc.UI;
using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Data;


namespace BurnsWilcoxCLP.Web.Controllers
{
    public class UserRightsController : BaseAdminController
    {
        // GET: UserRights

        private readonly UserAPIController _userapicontroller;
        public UserRightsController()
        {
            _userapicontroller = new UserAPIController();
        } 
      //  [Route("UserRights")]
        public ActionResult Index()
        {
            UserTypeEntity model = new UserTypeEntity();
            var userTypeList = _userapicontroller.GetUserTypelist();
            ViewBag.UserTypeId = new SelectList(userTypeList, "UserTypeId", "Name");
            return View(model);
        }
        public ActionResult UserAccesRight(short userTypeId)
        {
            var userTypeList = _userapicontroller.GetUserTypelist();
            ViewBag.UserTypeId = new SelectList(userTypeList, "UserTypeId", "Name",userTypeId);

            var userList = _userapicontroller.GetUserTypeMenuSearchlist(userTypeId);
            
            return Json(new{userList},JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult ReadUserTypeAction(DataSourceRequest request, short userTypeId)
        {
            var userList = _userapicontroller.GetUserTypeMenuSearchlist(userTypeId);
            return Json(userList.ToDataSourceResult(request));
        }

        public string Save(List<UserTypeMenuSearch> model)
        {
                try
                {
                    var serializer = new JavaScriptSerializer();

                    var userTypeMenuSearchList = model;

                    #region DataTable
                    DataTable dtUserTypeMenus = new DataTable("UserTypeMenusTable");
                    dtUserTypeMenus.Columns.Add("UserTypeMenuId");
                    dtUserTypeMenus.Columns.Add("MenuId");
                    dtUserTypeMenus.Columns.Add("UserTypeId");
                    dtUserTypeMenus.Columns.Add("IsView");
                    dtUserTypeMenus.Columns.Add("IsAdd");
                    dtUserTypeMenus.Columns.Add("IsDelete");
                    dtUserTypeMenus.Columns.Add("IsEdit");
                    #endregion

                    foreach (UserTypeMenuSearch objUserTypeMenuSearch in userTypeMenuSearchList)
                    {
                        DataRow dtrow = dtUserTypeMenus.NewRow();
                        dtrow["UserTypeMenuId"] = objUserTypeMenuSearch.UserTypeMenuId;
                        dtrow["MenuId"] = objUserTypeMenuSearch.MenuId;
                        dtrow["UserTypeId"] = objUserTypeMenuSearch.UserTypeId;
                        dtrow["IsView"] = objUserTypeMenuSearch.IsView;
                        dtrow["IsAdd"] = objUserTypeMenuSearch.IsAdd;
                        dtrow["IsDelete"] = objUserTypeMenuSearch.IsDelete;
                        dtrow["IsEdit"] = objUserTypeMenuSearch.IsEdit;
                        dtUserTypeMenus.Rows.Add(dtrow);
                    }

                    int count =  _userapicontroller.SaveUserTypeActions(dtUserTypeMenus);
                    if (count > 0)
                    {
                        this.SuccessNotification("Right Added");
                    }

               return string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
        }

    }
}