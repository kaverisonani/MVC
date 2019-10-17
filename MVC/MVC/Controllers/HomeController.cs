using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private EFContext context = new EFContext();

        public ActionResult List()
        {
            var customers = context.Customers.OrderBy(o => o.FirstName).ThenBy(p => p.LastName).ToList();
            return View(customers);
        }

        public ActionResult AddUpdate(Int32? id)
        {
            if (id == null)
            {
                ViewBag.TiTle = "Add";
                var customer = new Customer();
                return View("~/Views/Home/Save.cshtml", customer);
            }
            else
            {
                ViewBag.TiTle = "Update";
                Int64 customerID = Convert.ToInt64(id);
                var customers = context.Customers.Where(t => t.CustomerID == customerID).OrderBy(o => o.FirstName).ThenBy(p => p.LastName).SingleOrDefault();
                return View("~/Views/Home/Save.cshtml", customers);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer obj)
        {
            if (ModelState.IsValid)
            {
                if (Convert.ToInt64(obj.CustomerID) > 0)
                {
                    context.Entry(obj).State = EntityState.Modified;      //To Update all fields

                    ////To Update Induvidual fields
                    //context.Customers.Attach(obj);
                    //context.Entry(obj).Property(u => u.FirstName).IsModified = true;
                    //context.Entry(obj).Property(u => u.LastName).IsModified = true;
                }
                else
                {
                    context.Customers.Add(obj);
                }

                if (context.SaveChanges() > 0)
                {
                    TempData["Message"] = "Saved Successfully";
                }
                else
                {
                    TempData["Message"] = "Error whle saving";
                }
                return RedirectToAction("List", "Home");
            }

            return View("~/Views/Home/Save.cshtml", obj);
        }






    }
}
