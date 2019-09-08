using ABIY_One;
using ABIY_One.Models;
using ABIY_One.Models.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        ApplicationDbContext context;
        public FeedbackController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.feedbacks.ToList());
        }
        public ActionResult Thanks()
        {
            return View();
        }
        public ActionResult Create()
        {
            Common cm = new Common();
            FeedbackViewModel model = new FeedbackViewModel();
            model.Answers = cm.GetAnswers();
            return View(model);
        }
         [HttpPost]
        public async Task<ActionResult> Create(FeedbackViewModel model)
        {
            Common cm = new Common();

            if (ModelState.IsValid)
            {
                if (ModelState==null)
                {
                    return RedirectToAction("Index");
                }
                Customer c = new Customer();
                Product p = new Product();

                //context.feedbacks.Add(new ABIY_One.Models.Feedback() { Answer = model.Select, Comment=model.Comment, Email=model.Email, FullName=model.FullName});
                
                //Add Feedback

                context.feedbacks.Add(new ABIY_One.Models.Feedback()
                { Answer = model.Select,
                  Comment = model.Comment,
                  date = DateTime.Now,
                  FullName = model.FullName,
                  Email = c.Email });

                await context.SaveChangesAsync();
                return RedirectToAction("Thanks");
            }
            model.Answers = cm.GetAnswers();
            return View(model);
        }
    }
}