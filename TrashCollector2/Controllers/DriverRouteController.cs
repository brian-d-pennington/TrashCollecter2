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

        private List<DriverRoute> todaysRoute;
        
        // GET: DriverRoute
        [HttpGet]
        public ActionResult Index()
        {
            string dayOfRoute = DateTime.Today.DayOfWeek.ToString();
            GenerateRouteByDay(dayOfRoute);
            return View(todaysRoute);
        }

        [HttpGet]
        public ActionResult DayOne()
        {
            string dayOfRoute = "Monday";
            GenerateRouteByDay(dayOfRoute);
            if (todaysRoute.Count == 0)
            {
                return View("NoCustomers");
            }
            else
            {
                return View(todaysRoute);
            }
        }

        [HttpGet]
        public ActionResult DayTwo()
        {
            string dayOfRoute = "Tuesday";
            GenerateRouteByDay(dayOfRoute);
            if (todaysRoute.Count == 0)
            {
                return View("NoCustomers");
            }
            else
            {
                return View(todaysRoute);
            }
        }

        [HttpGet]
        public ActionResult DayThree()
        {
            string dayOfRoute = "Wednesday";
            GenerateRouteByDay(dayOfRoute);
            if (todaysRoute.Count == 0)
            {
                return View("NoCustomers");
            }
            else
            {
                return View(todaysRoute);
            }
        }

        [HttpGet]
        public ActionResult DayFour()
        {
            string dayOfRoute = "Thursday";
            GenerateRouteByDay(dayOfRoute);
            if (todaysRoute.Count == 0)
            {
                return View("NoCustomers");
            }
            else
            {
                return View(todaysRoute);
            }
        }

        [HttpGet]
        public ActionResult DayFive()
        {
            string dayOfRoute = "Friday";
            GenerateRouteByDay(dayOfRoute);
            if (todaysRoute.Count == 0)
            {
                return View("NoCustomers");
            }
            else
            {
                return View(todaysRoute);
            }
        }


        private List<DriverRoute> GenerateRouteByDay(string dayOfRoute)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DriverRoutes]");
            
            var driverToFind = User.Identity.GetUserId();
            Employee employeeRoute = context.Employees.Where(u => u.ApplicationId == driverToFind).SingleOrDefault();
            var customerPickupDay = context.Customers.Include(d => d.DaysOfTheWeek.Weekday);
            var customersInRoute = context.Customers.Include(d => d.DaysOfTheWeek).Where(c => c.Zip == employeeRoute.Route && c.DaysOfTheWeek.Weekday == dayOfRoute);
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
            todaysRoute = context.DriverRoutes.Include(d => d.Employee).Include(c => c.Customer).ToList();
            return todaysRoute;
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
            customerToCharge.AccumulatedCharges += 12.50;
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