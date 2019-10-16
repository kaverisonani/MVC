using MVC.Models;
using System;
using System.Collections.Generic;
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


            
    }
}
