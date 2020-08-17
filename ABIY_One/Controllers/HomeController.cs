using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using ABIY_One.Models;
using System.Threading.Tasks;
using System.IO;

namespace ABIY_One.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
           // ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Location()
        {

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Contact(/*EmailFormModel model*/)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //    //    var message = new MailMessage();
        //    //    message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
        //    //    message.From = new MailAddress("sender@outlook.com");  // replace with valid value
        //    //    message.Subject = "Your email subject";
        //    //    message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //    //    message.IsBodyHtml = true;

        //    //    if (model.Upload != null && model.Upload.ContentLength > 0)
        //    //    {
        //    //        message.Attachments.Add(new Attachment(model.Upload.InputStream, Path.GetFileName(model.Upload.FileName)));
        //    //    }

        //    //    using (var smtp = new SmtpClient())
        //    //    {

        //    //        await smtp.SendMailAsync(message);
        //    //        return RedirectToAction("Sent");
        //    //    }
        //    //}
        //    //return View(model);
        //    return View();

        //}
        public ActionResult Sent()
        {
            return View();
        }
    }
}