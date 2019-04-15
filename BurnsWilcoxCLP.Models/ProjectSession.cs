using System;
using System.Collections.Generic;
using System.Web;

namespace BurnsWilcoxCLP.Models
{
    public static class ProjectSession
    {
        /// <summary>
        /// Gets or sets the login user details.
        /// </summary>
        /// <value>The login user details.</value>
        public static User.LoginUser LoginUserDetails
        {
            get
            {
                return
                    HttpContext.Current.Session["LoginUserDetailsApp"] == null
                    ? null
                    : Newtonsoft.Json.JsonConvert.DeserializeObject<User.LoginUser>(Convert.ToString(HttpContext.Current.Session["LoginUserDetailsApp"]));
            }

            set
            {
                HttpContext.Current.Session["LoginUserDetailsApp"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }
        public static List<UserAccessPermissions> UserAccessPermissions
        {
            get
            {
                return HttpContext.Current.Session["UserAccessPermissions"] == null ? new List<UserAccessPermissions>() : HttpContext.Current.Session["UserAccessPermissions"] as List<UserAccessPermissions>;
            }
            set
            {
                HttpContext.Current.Session["UserAccessPermissions"] = value;
            }
        }
       
    }
}
