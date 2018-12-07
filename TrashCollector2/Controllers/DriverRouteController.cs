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
        public ActionResult Index()
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DriverRoute]");
            var today = DateTime.Today.DayOfWeek.ToString();
            var driverToFind = User.Identity.GetUserId();
            Employee employeeRoute = context.Employees.Where(u => u.ApplicationId == driverToFind).SingleOrDefault();
            var customerPickupDay = context.Customers.Include(d => d.DaysOfTheWeek.Weekday);
            var customersInRoute = context.Customers.Include(d => d.DaysOfTheWeek.Weekday).Where(c => c.Zip == employeeRoute.Route && c.DaysOfTheWeek.Weekday == today);
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
            var todaysRoute = context.DriverRoutes.ToList();
            return View(todaysRoute);
        }

        //public IEnumerable<DriverRoute> TodaysRoute()
        //{
        //    context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DriverRoute]");
        //    var today = DateTime.Today.DayOfWeek.ToString();
        //    var driverToFind = User.Identity.GetUserId();
        //    Employee employeeRoute = context.Employees.Where(u => u.ApplicationId == driverToFind).SingleOrDefault();
        //    var customerPickupDay = context.Customers.Include(d => d.DaysOfTheWeek.Weekday);
        //    var customersInRoute = context.Customers.Include(d => d.DaysOfTheWeek.Weekday).Where(c => c.Zip == employeeRoute.Route && c.DaysOfTheWeek.Weekday == today);
        //    foreach (var c in customersInRoute)
        //    {
        //        DriverRoute driverRoute = new DriverRoute()
        //        {
        //            EmployeeId = employeeRoute.ID,
        //            CustomerId = c.ID
        //        };
        //        context.DriverRoutes.Add(driverRoute);
        //    }
        //    context.SaveChanges();
        //    var todaysRoute = context.DriverRoutes.ToList();
        //    return todaysRoute;
        // }

    }
}