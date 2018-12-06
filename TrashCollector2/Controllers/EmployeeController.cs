using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            var employeeToFind = User.Identity.GetUserId();
            Employee loggedInEmployee = context.Employees.Where(u => u.ApplicationId == employeeToFind).SingleOrDefault();
            return View(loggedInEmployee);
        }
    }
}