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
        public ActionResult Edit(int id)
        {
            var loggedInCustomer = context.Customers.Where(c => c.ID == id).Single();
            loggedInCustomer.Days = context.DaysOfTheWeeks.ToList();
            return View(loggedInCustomer);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Customer loggedInCustomer)
        {
            var getCurrentUser = User.Identity.GetUserId();
            Customer customerToEdit = context.Customers.Where(u => u.ApplicationId == getCurrentUser).SingleOrDefault();
            DateTime SpecialRequest = new DateTime(loggedInCustomer.Year, loggedInCustomer.Month, loggedInCustomer.Day);
            DateTime SuspendStartDate = new DateTime(loggedInCustomer.Year2, loggedInCustomer.Month2, loggedInCustomer.Day2);
            DateTime ResumeServiceDate = new DateTime(loggedInCustomer.Year3, loggedInCustomer.Month3, loggedInCustomer.Day3);

            customerToEdit.WeekdayID = loggedInCustomer.WeekdayID;
            customerToEdit.SpecialRequest = SpecialRequest;
            customerToEdit.SuspendStartDate = SuspendStartDate;
            customerToEdit.ResumeServiceDate = ResumeServiceDate;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}