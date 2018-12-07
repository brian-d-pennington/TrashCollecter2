using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;
using System.Data.Entity;


namespace TrashCollector2.Controllers
{
    public class DriverRouteController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: DriverRoute
        [HttpGet]
        public ActionResult Index()
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DriverRoutes]");
            string today = DateTime.Today.DayOfWeek.ToString();
            var driverToFind = User.Identity.GetUserId();
            Employee employeeRoute = context.Employees.Where(u => u.ApplicationId == driverToFind).SingleOrDefault();
            var customerPickupDay = context.Customers.Include(d => d.DaysOfTheWeek.Weekday);
            var customersInRoute = context.Customers.Include(d => d.DaysOfTheWeek).Where(c => c.Zip == employeeRoute.Route && c.DaysOfTheWeek.Weekday == today);
            foreach (var c in customersInRoute)
            {
                DriverRoute driverRoute = new DriverRoute()
                {
                    EmployeeId = employeeRoute.ID,
                    CustomerId = c.ID
                };
                context.DriverRoutes.Add(driverRoute);
            }
            context.SaveChanges();
            var todaysRoute = context.DriverRoutes.Include(d => d.Employee).Include(c => c.Customer).ToList();
            return View(todaysRoute);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var addressToMarkAsComplete = context.Customers.SingleOrDefault(m => m.ID == id);
            return View(addressToMarkAsComplete);
        }

        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            var routeComplete = context.DriverRoutes.Where(r => r.ID == id).Single();
            int localId = routeComplete.CustomerId;
            Customer customerToCharge = context.Customers.Where(c => c.ID == localId).Single();
            customerToCharge.AccumulatedCharges = 12.50;
            context.DriverRoutes.Remove(routeComplete);
            context.SaveChanges();

            DriverRoute firstTableItem;

            try
            {
                firstTableItem = context.DriverRoutes.First();
                return View("Index");
            }
            catch
            {
                return View("Complete");
            }
            
        }

      
    }
}