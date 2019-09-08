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
    public class UploadDesignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: UploadDesigns
        public ActionResult Index()
        {
            var uploadDesigns = db.UploadDesigns.Include(u => u.designArea).Include(u => u.designSize);
            return View(uploadDesigns.ToList());
        }
        public ActionResult UploadView()
        {
            var uploadDesigns = db.UploadDesigns.Include(u => u.designArea).Include(u => u.designSize);
            return View(uploadDesigns);
        }
        // GET: UploadDesigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadDesign uploadDesign = db.UploadDesigns.Find(id);
            if (uploadDesign == null)
            {
                return HttpNotFound();
            }
            return View(uploadDesign);
        }

        // GET: UploadDesigns/Create
        public ActionResult Create()
        {
            ViewBag.PrintAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName");
            ViewBag.PrintSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName");
            return View();
        }

        // POST: UploadDesigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UploadId,UploadName,PrintImage,PrintSizeId,PrintAreaId")] UploadDesign uploadDesign, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    int fileLength = upload.ContentLength;
                    Byte[] array = new Byte[fileLength];
                    upload.InputStream.Read(array, 0, fileLength);
                    uploadDesign.PrintImage = array;
                    db.UploadDesigns.Add(uploadDesign);
                    db.SaveChanges();
                    return RedirectToAction("Thanks2");
                }
            }

            ViewBag.PrintAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName", uploadDesign.PrintAreaId);
            ViewBag.PrintSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName", uploadDesign.PrintSizeId);
            return View(uploadDesign);
        }
        public ActionResult Thanks2(/*int? id*/)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //UploadDesign uploadDesign = db.UploadDesigns.Find(id);
            //if (uploadDesign == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(uploadDesign);
            return View();
        }
        // GET: UploadDesigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadDesign uploadDesign = db.UploadDesigns.Find(id);
            if (uploadDesign == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrintAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName", uploadDesign.PrintAreaId);
            ViewBag.PrintSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName", uploadDesign.PrintSizeId);
            return View(uploadDesign);
        }

        // POST: UploadDesigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UploadId,UploadName,PrintImage,PrintSizeId,PrintAreaId")] UploadDesign uploadDesign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uploadDesign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrintAreaId = new SelectList(db.DesignAreas, "DesignAreaId", "AreaName", uploadDesign.PrintAreaId);
            ViewBag.PrintSizeId = new SelectList(db.DesignSizes, "DsizeId", "SizeName", uploadDesign.PrintSizeId);
            return View(uploadDesign);
        }

        // GET: UploadDesigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadDesign uploadDesign = db.UploadDesigns.Find(id);
            if (uploadDesign == null)
            {
                return HttpNotFound();
            }
            return View(uploadDesign);
        }

        // POST: UploadDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UploadDesign uploadDesign = db.UploadDesigns.Find(id);
            db.UploadDesigns.Remove(uploadDesign);
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