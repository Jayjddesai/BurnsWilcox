using BurnsWilcoxCLP.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Web.Controllers
{
    public class BaseAdminController : Controller
    {
        

        /// <summary>
        /// Display success notification
        /// </summary>
        /// <param name="message">The Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="saveInSession">save message in session</param>
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true, bool saveInSession = false)
        {
            AddNotification(Enums.NotifyType.Success, message, persistForTheNextRequest, saveInSession);
        }

        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="message">The Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="saveInSession">if set to <c>true</c> [save in session].</param>
        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true, bool saveInSession = false)
        {
            AddNotification(Enums.NotifyType.Error, message, persistForTheNextRequest, saveInSession);
        }

        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="exception">The Exception</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="logException">A value indicating whether exception should be logged</param>
        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true, bool logException = true)
        {
            AddNotification(Enums.NotifyType.Error, exception.Message, persistForTheNextRequest, false);
        }

        /// <summary>
        /// Display notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="message">the Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="saveInSession">if set to <c>true</c> [save in session].</param>
        
        protected virtual void AddNotification(Enums.NotifyType type, string message, bool persistForTheNextRequest, bool saveInSession)
        {
            var dataKey = string.Format("tmp.notifications.{0}", type);

            if (!saveInSession)
            {
                if (persistForTheNextRequest)
                {
                    if (TempData[dataKey] == null)
                    {
                        TempData[dataKey] = new List<string>();
                    }

                    ((List<string>)TempData[dataKey]).Add(message);
                }
                else
                {
                    if (ViewData[dataKey] == null)
                    {
                        ViewData[dataKey] = new List<string>();
                    }

                    ((List<string>)ViewData[dataKey]).Add(message);
                }
            }
            else
            {
                if (Session[dataKey] == null)
                {
                    Session[dataKey] = new List<string>();
                }

                ((List<string>)Session[dataKey]).Add(message);
            }
        }

    }
    }
