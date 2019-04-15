using BurnsWilcoxCLP.API.API;
using BurnsWilcoxCLP.Models;
using BurnsWilcoxCLP.Web.EmailHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class LoginController : BaseAdminController
    {
        // GET: Login

        private readonly UserAPIController _userapicontroller;
        private readonly CommonAPIController _CommonAPIController;

        public LoginController()
        {
            _userapicontroller = new UserAPIController();
            _CommonAPIController = new CommonAPIController();
        }

        [HttpGet]
        public ActionResult Index()
        {
            LoginEntity model = new LoginEntity();
            return View(model);

        }
        [HttpPost]
        public ActionResult Index(LoginEntity model)
        {
            //var list = testAPIController.GetStateNameList().ToDataSourceResult(request);
            if (ModelState.IsValid)
            {
                var result = _userapicontroller.AuthenticateUser(model.EmailAddress, model.Password);
                if (result != null)
                {
                    //var objLoginUserDetails = result;
                    //ProjectSession.LoginUserDetails = objLoginUserDetails;

                    ProjectSession.LoginUserDetails = result;
                    ProjectSession.UserAccessPermissions = _userapicontroller.UserAccessPermissions(result.UserTypeId);
                    return RedirectToAction("index", "Home");
                    //if (model.RememberMe)
                    //{
                    //    var userData = JsonConvert.SerializeObject(model);
                    //    var authTicket = new FormsAuthenticationTicket(
                    //        1,
                    //        model.Email,
                    //        DateTime.Now,
                    //        DateTime.Now.AddDays(30),
                    //        model.RememberMe, // pass here true, if you want to implement remember me functionality
                    //        userData);
                    //    var encTicket = FormsAuthentication.Encrypt(authTicket);
                    //    var facookie = new HttpCookie("FXSystemCookie", encTicket) { Expires = DateTime.Now.AddDays(30) };
                    //    Response.Cookies.Add(facookie);
                    //}
                    //else
                    //{
                    //    if (Request.Cookies["FXSystemCookie"] == null) return model;
                    //    var myCookie = new HttpCookie("FXSystemCookie") { Expires = DateTime.Now.AddDays(-1d) };
                    //    Response.Cookies.Add(myCookie);
                    //}
                }
                else
                {
                    this.ErrorNotification("Email or password invalid");
                    return View();
                     //ModelState.AddModelError("Password", FXSystemResource.UsernamePassworddoesnotmatch);
                }

            }
            return View(model);


        }

        #region UserRegistration

        [HttpGet]
        //[Route("UserRegistration")]
        public ActionResult UserRegistration()
        {
            //GetStateList(countryId);
            GetCountryList();
            Getstate();
            UserAgency model = new UserAgency();
            return View(model);
        }


        [HttpPost]
        public ActionResult UserRegistration(UserAgency model)
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
                    this.SuccessNotification("User Registered Successfully");
                }
            }
            catch (Exception ex)
            {
                this.ErrorNotification("Error Occurred!");
                return View(model);
            }

            return RedirectToAction("Index", "Login");
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

        #region ForgetPasswordLink
        public ActionResult ForgetPasswordLink(string EmailAdress)
        {
            UserEntity model = new UserEntity();
            model = _userapicontroller.UserExistbasedonEmail(EmailAdress);
            if (model != null)
            {

                string link = Url.Action("ResetPassword", "Login", new RouteValueDictionary(new { UserId = model.UserId }), System.Web.HttpContext.Current.Request.Url.Scheme,
                       System.Web.HttpContext.Current.Request.Url.Host);
                string resetlink = "resetlink";

                string resetLink = "<a href='" + link + "'>" + resetlink + "</a>";
                var to = EmailAdress;
                string bodyTemplate = System.IO.File.ReadAllText(Server.MapPath("~/MailTemplate/ForgetPassword.html"));
                //bodyTemplate = bodyTemplate.Replace("[@HeaderImg]", str);
                bodyTemplate = bodyTemplate.Replace("[@DisplayName]", model.DisplayName);
                bodyTemplate = bodyTemplate.Replace("[@link]", resetLink);
                Task task = new Task(() => Email.Send(EmailAdress, bodyTemplate, "ForgetPassword Link"));
                task.Start();


            }
            else
            {

            }
            return Json(true);
        }
        #endregion
        #region Resetpassword
        [HttpGet]
        public ActionResult ResetPassword(int UserId)
        {
            UserEntity model = new UserEntity();
            model = _userapicontroller.GetUserById(UserId);
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPassword(UserEntity model)
        {

            int ResetPassword = _userapicontroller.ResetPassword(model);
            if (ResetPassword > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            return View(model);
        }

        #endregion


    }
}