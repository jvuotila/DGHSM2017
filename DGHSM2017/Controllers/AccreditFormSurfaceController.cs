using System.Web.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Web.Configuration;
using System;
using System.Text;
using DGHSM2017.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DGHSM2017.Controllers
{
    public class AccreditFormSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        private string BuildAccreditEmail(AccreditFormViewModel AccreditMessage)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>Etunimi:</b> " + AccreditMessage.FirstName).Append("<br/>");
            sb.Append("<b>Sukunimi:</b> " + AccreditMessage.LastName).Append("<br/>");
            sb.Append("<b>Mediatalo:</b> " + AccreditMessage.Media).Append("<br/>");
            sb.Append("<b>Sähköpostiosoite:</b> " + AccreditMessage.EmailAddress).Append("<br/>");
            sb.Append("<b>Puhelinnumero:</b> " + AccreditMessage.PhoneNumber).Append("<br/>&nbsp;<br/>");
            sb.Append("<b>KALUSTO</b>").Append("<br/>");

            if (AccreditMessage.Interview)
            {
                sb.Append("- Haastattelu").Append("<br/>");
            }
            
            if (AccreditMessage.Photography)
            {
                sb.Append("- Valokuvaus").Append("<br/>");
            }
            
            if (AccreditMessage.Video)
            {
                sb.Append("- Video").Append("<br/>&nbsp;<br/>");
            }

            sb.Append("<b>PÄIVÄT</b>").Append("<br/>");

            if (AccreditMessage.Day1)
            {
                sb.Append("- Torstai").Append("<br/>");
            }


            if (AccreditMessage.Day2)
            {
                sb.Append("- Perjantai").Append("<br/>");
            }


            if (AccreditMessage.Day3)
            {
                sb.Append("- Lauantai").Append("<br/>");
            }


            if (AccreditMessage.Day4)
            {
                sb.Append("- Sunnuntai");
            }

            return sb.ToString();
        }

        [HttpPost]
        [ActionName("CreateAccreditMessage")]
        public ActionResult CreateAccreditMessagePost(AccreditFormViewModel AccreditMessage)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            ViewBag.Accredit = AccreditMessage;
            
            var apiKey = WebConfigurationManager.AppSettings["SENDGRID_APIKEY"];
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress(AccreditMessage.EmailAddress));
            var recipients = new List<EmailAddress>
            {
                new EmailAddress(WebConfigurationManager.AppSettings["contactEmailAddress"])
            };
            msg.AddTos(recipients);
            msg.SetSubject("Akkreditiontihakemus: " + AccreditMessage.FirstName + " " + AccreditMessage.LastName);
            msg.AddContent(MimeType.Html, BuildAccreditEmail(AccreditMessage));

            try
            {
                var response = client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            return CurrentUmbracoPage();
        }
    }
}