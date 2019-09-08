using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABIY_One.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Bad_Request()
        {
            return View();
        }
        public ActionResult Not_Found()
        {
            return View();
        }
    }
}