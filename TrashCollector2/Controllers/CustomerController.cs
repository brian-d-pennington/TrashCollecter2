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
        public ActionResult Edit(Customer loggedInCustomer)
        {
            loggedInCustomer.Days = context.DaysOfTheWeeks.ToList();
            return View(loggedInCustomer);
        }

        //POST
        [HttpPost]
        public ActionResult Edit()
        {
            var getCurrentUser = User.Identity.GetUserId();
            Customer customerToEdit = context.Customers.Where(u => u.ApplicationId == getCurrentUser).SingleOrDefault();
            Customer customer = new Customer();
            //DateTime date1 = new DateTime(year, month, day);

            //customerToEdit.WeekdayID = customer.Day;
            customerToEdit.SpecialRequest = customer.SpecialRequest;
            customerToEdit.SuspendStartDate = customer.SuspendStartDate;
            customerToEdit.ResumeServiceDate = customer.ResumeServiceDate;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}