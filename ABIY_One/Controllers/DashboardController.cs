using ABIY_One.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABIY_One.Controllers
{
    public class DashboardController : Controller
    {
     
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.NewOrders = db.Orders.OrderByDescending(a => a.Order_ID).Take(10).Count();
            ViewBag.Packed = db.Orders.Where(a => a.packed == true && a.shipped == false).Count();
            ViewBag.Shipped = db.Orders.Where(a => a.packed == true && a.shipped == true).Count();
            ViewBag.ExpectedProfit = db.Products.OrderByDescending(a => a.ItemCode).Take(10).Count();


            return View();
        }



        //Pie Chart
        public JsonResult GetTopProductSales()
        {
            var dataforchart = (from P in db.Order_Items
                                select new { P.Item.Name, P.quantity } into row
                                group row by row.Name into g
                                select new
                                {
                                    label = g.Key,
                                    value = g.Sum(x => x.quantity)
                                })
                    .OrderByDescending(x => x.value)
                    .Take(5);
            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }



        //Line Graph uncomment
        public JsonResult GetOrderPerDay()
        {
            var data = from O in db.Order_Items
                       select new { Odate = EntityFunctions.TruncateTime(O.Order.date_created), O.Order_id } into g
                       group g by g.Odate into col
                       select new
                       {
                           Order_Date = col.Key,
                           Count = col.Count(y => y.Order_id != null)
                       };


            List<LineCharts> aa = new List<LineCharts>();
            foreach (var item in data)
            {
                string date = item.Order_Date.ToString().Split(new[] { (' ') }, StringSplitOptions.None)[0];
                aa.Add(new LineCharts() { Date = date, Orders = item.Count });
            }
            return Json(aa, JsonRequestBehavior.AllowGet);
        }

        //Bar Graph
        public JsonResult GetSalesPerCountry()
        {
            var dataforBarchart = (from O in db.Products
                                   select new { O.Name, O.QuantityInStock } into row
                                   group row by row.Name into g
                                   select new
                                   {
                                       Country = g.Key,
                                       Quantity = g.Sum(x => x.QuantityInStock)
                                   })
                              .OrderByDescending(x => x.Quantity)
                              .Take(6);
            return Json(dataforBarchart, JsonRequestBehavior.AllowGet);
        }

    }
}