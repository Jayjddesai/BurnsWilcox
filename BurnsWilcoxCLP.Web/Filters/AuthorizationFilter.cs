//-----------------------------------------------------------------------
// <copyright file="AuthorizationFilter.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BurnsWilcoxCLP.Web.Filters
{
    /// <summary>
    /// Class AuthorizeUserAttribute. This class cannot be inherited.
    /// </summary>
    public sealed class AuthorizeUserAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// ENUMS AdminModule
        /// </summary>
        public enum AdminModule
        {
            /// <summary>
            /// The title
            /// </summary>
            Title,

            /// <summary>
            /// The title attributes
            /// </summary>
            TitleAttributes,

            /// <summary>
            /// The title type
            /// </summary>
            TitleType,

            /// <summary>
            /// The title type relation
            /// </summary>
            TitleTypeRelation,

            /// <summary>
            /// The service fields
            /// </summary>
            ServiceFields,

            /// <summary>
            /// The service territory
            /// </summary>
            ServiceTerritory,

            /// <summary>
            /// The service language
            /// </summary>
            ServiceLanguage
        }

        /// <summary>
        /// Gets or sets the rights.
        /// Custom Rights
        /// </summary>
        /// <value>The rights.</value>
        public AdminModule Rights { get; set; }

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>true if the user is authorized; otherwise, false.</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // string userRights = string.Join(string.Empty, GetUserRights(httpContext.User.Identity.Name.ToString())); // Call another method to get rights of the user from DB
            string userRights = "Title,TitleType";

            if (userRights.Contains(Rights.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Processes HTTP requests that fail authorization.
        /// </summary>
        /// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute" />. The <paramref name="filterContext" /> object contains the controller, HTTP context, request context, action result, and route data.</param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Unauthorised" }));
        }
    }

    /// <summary>
    /// Class AjaxErrorHandler. This class cannot be inherited.
    /// </summary>
    public sealed class AjaxErrorHandler : HandleErrorAttribute
    {
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The action-filter context.</param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        filterContext.Exception.Message,
                        filterContext.Exception.StackTrace
                    }
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }
}