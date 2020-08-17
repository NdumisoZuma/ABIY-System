using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABIY_One.ABIY_Business_Logic;
using ABIY_One.Models;
using ABIY_One.Models.Data_Models;

namespace ABIY_One.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Product_Business pb = new Product_Business();
        Category_Business cb = new Category_Business();
        public string shoppingCartID { get; set; }
        public const string CartSessionKey = "CartId";

        public ProductsController() { }
        public ActionResult Index(string option, string search)
        {

            //var products = db.Categories();
            return View(db.Products.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            // return View(pb.all());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (pb.find_by_id(id) != null)
                return View(pb.find_by_id(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }

        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(cb.all(), "Category_ID", "Category_Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model, HttpPostedFileBase img_upload)
        {
            ViewBag.Category_ID = new SelectList(cb.all(), "Category_ID", "Category_Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName");

            byte[] data = null;
            data = new byte[img_upload.ContentLength];
            img_upload.InputStream.Read(data, 0, img_upload.ContentLength);
            model.Picture = data;
            model.Price = model.CalcSellingPrice();
            model.ExpectedProfit = model.CalcExpctdProft();
            if (ModelState.IsValid)
            {
                pb.add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Category_ID = new SelectList(cb.all(), "Category_ID", "Category_Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName");

            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (pb.find_by_id(id) != null)
                return View(pb.find_by_id(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model, HttpPostedFileBase img_upload)
        {
            byte[] data = null;
            data = new byte[img_upload.ContentLength];
            img_upload.InputStream.Read(data, 0, img_upload.ContentLength);
            model.Picture = data;
            model.Price = model.CalcSellingPrice();
            if (ModelState.IsValid)
            {
                pb.edit(model);
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(cb.all(), "Category_ID", "Category_Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName");

            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (pb.find_by_id(id) != null)
                return View(pb.find_by_id(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pb.delete(pb.find_by_id(id));
            return RedirectToAction("Index");
        }


        public ActionResult Fall_catalog()
        {
            return View(pb.all());
        }

        public string GetCartID()
        {
            if (System.Web.HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    System.Web.HttpContext.Current.Session[CartSessionKey] = System.Web.HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid temp_cart_ID = Guid.NewGuid();
                    System.Web.HttpContext.Current.Session[CartSessionKey] = temp_cart_ID.ToString();
                }
            }
            return System.Web.HttpContext.Current.Session[CartSessionKey].ToString();
        }
        public ActionResult Specials()
        {
            return View(db.Specials.ToList());
        }

        public ActionResult MakeSpecial(int? id)
        {
            Product item = db.Products.Find(id);

            Special special = new Special();

            special.Category_ID = item.Category_ID;
            special.SizeId = item.SizeId;
            special.Description = item.Description;
            special.Name = item.Name;
            special.oldPrice = item.Price;
            special.Picture = item.Picture;
            special.QuantityInStock = item.QuantityInStock;

            ViewBag.Category = db.Categories.Find(item.Category_ID).Category_Name;
            ViewBag.Size = db.Sizes.Find(item.SizeId).SizeName;

            return View(special);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeSpecial(Special special)
        {
            Product item = db.Products.Where(x => x.Name == special.Name).FirstOrDefault();

            special.SetDiscount();
            special.SetPrice();

            if (db.Specials.Any(x => x.Description == special.Description && x.discountPercent == special.discountPercent && x.Name == special.Name))
            {
                var specItem = db.Specials.FirstOrDefault(x => x.Description == special.Description &&
                x.discountPercent == special.discountPercent && x.Name == special.Name);

                specItem.QuantityInStock += special.QuantityInStock;
                item.QuantityInStock -= special.QuantityInStock;
                db.SaveChanges();
                return RedirectToAction("Specials");
            }

            db.Specials.Add(special);

            item.QuantityInStock -= special.QuantityInStock;

            db.SaveChanges();

            return RedirectToAction("Specials");
        }
    }
}
