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
        public ApplicationDbContext context = new ApplicationDbContext();



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

            loggedInCustomer.Day = context.Customers.Select(d => d.Day).Single();
            loggedInCustomer.Month = context.Customers.Select(d => d.Month).Single();
            loggedInCustomer.Year = context.Customers.Select(d => d.Year).Single();

            loggedInCustomer.Day2 = context.Customers.Select(d => d.Day2).Single();
            loggedInCustomer.Month2 = context.Customers.Select(d => d.Month2).Single();
            loggedInCustomer.Year2 = context.Customers.Select(d => d.Year2).Single();

            loggedInCustomer.Day3 = context.Customers.Select(d => d.Day3).Single();
            loggedInCustomer.Month3 = context.Customers.Select(d => d.Month3).Single();
            loggedInCustomer.Year3 = context.Customers.Select(d => d.Year3).Single();
            return View(loggedInCustomer);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Customer loggedInCustomer)
        {
            var getCurrentUser = User.Identity.GetUserId();
            Customer customerToEdit = context.Customers.Where(u => u.ApplicationId == getCurrentUser).SingleOrDefault();
            customerToEdit.Day = loggedInCustomer.Day;
            customerToEdit.Month = loggedInCustomer.Month;
            customerToEdit.Year = loggedInCustomer.Year;
            customerToEdit.Day2 = loggedInCustomer.Day2;
            customerToEdit.Month2 = loggedInCustomer.Month2;
            customerToEdit.Year2 = loggedInCustomer.Year2;
            customerToEdit.Day3 = loggedInCustomer.Day3;
            customerToEdit.Month3 = loggedInCustomer.Month3;
            customerToEdit.Year3 = loggedInCustomer.Year3;

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