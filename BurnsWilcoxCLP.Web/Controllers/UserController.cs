using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BurnsWilcoxCLP.API.API;
using BurnsWilcoxCLP.Models;
using System.Threading.Tasks;
using BurnsWilcoxCLP.Web.EmailHelper;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class UserController : BaseAdminController
    {
        // GET: User

        private readonly UserAPIController _userapicontroller;
        private readonly CommonAPIController _CommonAPIController;

        public UserController()
        {
            _userapicontroller = new UserAPIController();
            _CommonAPIController = new CommonAPIController();
        }

        #region User List
        public ActionResult Index()
        {
            List<UserMasterList> userlist = _userapicontroller.GetUserMasterList();
            return View("Users", userlist);
        }

        public ActionResult DeleteUser(int UserId)
        {
            int result = 0;
            try
            {
                string message = _userapicontroller.DeleteUserById(UserId);

                string[] msg = message.Split('|');
                if (msg.Length > 0)
                {
                    result = Convert.ToInt32(msg[0]);
                }

                if (msg.Length > 1)
                {
                    if (msg[1] != "")
                    {
                        this.ErrorNotification(msg[1].ToString());
                        return RedirectToAction("Index", "User");
                    }
                }

                if (result > 0)
                {
                    this.SuccessNotification("User Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                this.ErrorNotification("Error Occurred!");
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Index", "User");
        }

        #endregion

        #region Manage Users
        [HttpGet]
        public ActionResult AddUser()
        {
            GetCountryList();
            Getstate();
            UserAgency model = new UserAgency();
            return View("ManageUser", model);
        }

        [HttpGet]
        public ActionResult ManageUser(int UserId)
        {
            GetCountryList();
            Getstate();
            UserAgency model = new UserAgency();
            model = _userapicontroller.GetUserDetailsById(UserId);
            return View(model);
        }

        [HttpPost]
        public ActionResult ManageUser(UserAgency model)
        {
            int UserId = 0;
            try
            {
                string message = _userapicontroller.AddUser(model);
                GetCountryList();
                Getstate();

                string[] msg = message.Split('|');
                if (msg.Length > 0)
                {
                    UserId = Convert.ToInt32(msg[0]);
                }
                if (msg.Length > 1)
                {
                    if (msg[1] != "")
                    {
                        this.ErrorNotification(msg[1].ToString());
                        return View(model);
                    }
                }

                if (UserId > 0)
                {
                    var to = model.EmailAddress;
                    string bodyTemplate = System.IO.File.ReadAllText(Server.MapPath("~/MailTemplate/Registration.html"));
                    bodyTemplate = bodyTemplate.Replace("[@DisplayName]", model.DisplayName);
                    Task task = new Task(() => Email.Send(to, bodyTemplate, "Registration Link"));
                    task.Start();
                    this.SuccessNotification("User Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                this.ErrorNotification("Error Occurred!");
                return View(model);
            }

            return RedirectToAction("Index", "User");
        }
        #endregion


        #region BindState
        [HttpPost]
        public JsonResult GetStateList(int CountryId)
        {
            var StateList = _CommonAPIController.GetStateList(CountryId);
            ViewBag.StateId = new SelectList(StateList, "StateId", "StateName");
            return Json(StateList, JsonRequestBehavior.AllowGet);

        }

        public void Getstate()
        {
            var StateList = _CommonAPIController.GetStateList(0);
            ViewBag.StateId = new SelectList(StateList, "StateId", "StateName");

        }
        #endregion

        #region BindCountry
        public void GetCountryList()
        {
            var CountryList = _CommonAPIController.GetCountryList();
            ViewBag.CountryId = new SelectList(CountryList, "CountryId", "CountryName");
        }
        #endregion

        public ActionResult Users()
        {
            List<SelectListItem> userRole = new List<SelectListItem>();
            userRole.Add(new SelectListItem { Text = "Approval" });
            userRole.Add(new SelectListItem { Text = "Rejection" });
            userRole.Add(new SelectListItem { Text = "Lock User" });
            ViewData["userRole"] = userRole;
            return View();
        }

        public ActionResult GetExternalUserList()
        {
            var GetExternalUserList = _userapicontroller.GetExternalUserList();
            return Json(new { GetExternalUserList }, JsonRequestBehavior.AllowGet);
        }
    }
}