using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        

        // GET: Customer
        public ActionResult Index()
        {
            var customerToFind = User.Identity.GetUserId();
            var foundCustomer = context.Customers.Where(u => u.ApplicationId == customerToFind);
            return View(foundCustomer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var weekdays = context.DaysOfTheWeeks.ToList();
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Customer foundCustomer)
        //{

        //}
    }
}