using ABIY_One.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ABIY_One.Controllers
{
    public class DesignSizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DesignSizes
        public ActionResult Index()
        {
            return View(db.DesignSizes.ToList());
        }

        // GET: DesignSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignSize designSize = db.DesignSizes.Find(id);
            if (designSize == null)
            {
                return HttpNotFound();
            }
            return View(designSize);
        }

        // GET: DesignSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DsizeId,SizeName")] DesignSize designSize)
        {
            if (ModelState.IsValid)
            {
                db.DesignSizes.Add(designSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designSize);
        }

        // GET: DesignSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignSize designSize = db.DesignSizes.Find(id);
            if (designSize == null)
            {
                return HttpNotFound();
            }
            return View(designSize);
        }

        // POST: DesignSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DsizeId,SizeName")] DesignSize designSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designSize);
        }

        // GET: DesignSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignSize designSize = db.DesignSizes.Find(id);
            if (designSize == null)
            {
                return HttpNotFound();
            }
            return View(designSize);
        }

        // POST: DesignSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignSize designSize = db.DesignSizes.Find(id);
            db.DesignSizes.Remove(designSize);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}