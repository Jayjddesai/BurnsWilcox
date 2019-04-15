using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.IO;
using System.Threading.Tasks;

namespace BurnsWilcoxCLP.Web.EmailHelper
{
    public class Email
    {
        public static bool Send(string mailTo, string bodyTemplate, string subject = "", string ccMail = "")
        {
            var email = System.Configuration.ConfigurationManager.AppSettings["Email"];
            var password = System.Configuration.ConfigurationManager.AppSettings["passsword"];
            int PortNumber = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PortNumber"]);
            string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];
            MailMessage mail = new MailMessage();
            mail.To.Add(mailTo);
            mail.From = new MailAddress(email);
            mail.Subject = subject;
            mail.Body = bodyTemplate;
            mail.IsBodyHtml = true;

            if (ccMail != "" && ccMail != null)
            {
                mail.CC.Add(ccMail);
            }

            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            smtp.Host = HostName;

            //smtp.Port = 587;
            smtp.Port = PortNumber;

            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential
            //("yuvraj.ljmca@gmail.com", "");// Enter seders User name and password
            smtp.Credentials = new System.Net.NetworkCredential(email, password);// Enter seders User name and password
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

    }
}