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
        [HttpGet]
        public ActionResult Index()
        {
            var customerToFind = User.Identity.GetUserId();
            Customer loggedInCustomer = context.Customers.Where(u => u.ApplicationId == customerToFind).SingleOrDefault();
            return View(loggedInCustomer);
        }

        // GET: Edit page
        [HttpGet]
        public ActionResult Edit(Customer loggedInCustomer, DaysOfTheWeek daysOfTheWeek)
        {
            //ViewBag.Days = new SelectList(context.DaysOfTheWeeks.ToList(), "Day");
            loggedInCustomer.Days = context.DaysOfTheWeeks.ToList();
            return View(loggedInCustomer);
        }
    }
}