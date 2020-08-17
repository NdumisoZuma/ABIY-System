using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABIY_One.Models;

namespace ABIY_One.Controllers
{
    public class DesignVMsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DesignVMs
        public ActionResult Index()
        {
            var designVMs = db.DesignVMs.Include(d => d.area2).Include(d => d.design).Include(d => d.size);
            return View(designVMs.ToList());
        }

        // GET: DesignVMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignVM designVM = db.DesignVMs.Find(id);
            if (designVM == null)
            {
                return HttpNotFound();
            }
            return View(designVM);
        }

        // GET: DesignVMs/Create
        public ActionResult Create()
        {
            ViewBag.DesignAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName");
            ViewBag.DId = new SelectList(db.Designs, "DesignId", "DesignName");
            ViewBag.DesignSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName");
            return View();
        }

        // POST: DesignVMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DVMid,DId,DesignAreaId,DesignSizeId")] DesignVM designVM)
        {
            if (ModelState.IsValid)
            {
                db.DesignVMs.Add(designVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName", designVM.DesignAreaId);
            ViewBag.DId = new SelectList(db.Designs, "DesignId", "DesignName", designVM.DId);
            ViewBag.DesignSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName", designVM.DesignSizeId);
            return View(designVM);
        }

        // GET: DesignVMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignVM designVM = db.DesignVMs.Find(id);
            if (designVM == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName", designVM.DesignAreaId);
            ViewBag.DId = new SelectList(db.Designs, "DesignId", "DesignName", designVM.DId);
            ViewBag.DesignSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName", designVM.DesignSizeId);
            return View(designVM);
        }

        // POST: DesignVMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DVMid,DId,DesignAreaId,DesignSizeId")] DesignVM designVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName", designVM.DesignAreaId);
            ViewBag.DId = new SelectList(db.Designs, "DesignId", "DesignName", designVM.DId);
            ViewBag.DesignSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName", designVM.DesignSizeId);
            return View(designVM);
        }

        // GET: DesignVMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignVM designVM = db.DesignVMs.Find(id);
            if (designVM == null)
            {
                return HttpNotFound();
            }
            return View(designVM);
        }

        // POST: DesignVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignVM designVM = db.DesignVMs.Find(id);
            db.DesignVMs.Remove(designVM);
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
