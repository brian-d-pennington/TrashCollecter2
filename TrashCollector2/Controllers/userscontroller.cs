using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class UsersController : Controller
    {
        [Authorize]
        // GET: User
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                //AssignCustomer(RegisterViewModel model);
                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();

        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        /*     } */       //public void AssignCustomer(RegisterViewModel model)
                          //{
                          //    ApplicationDbContext context = new ApplicationDbContext();
                          //    if (model.UserRoles == "Customer")
                          //    {
                          //        var userId = User.Identity.GetUserId();

        //        context.Customers.Add(
        //        new Models.Customer
        //        {
        //            Email = model.Email,
        //            UserName = model.UserName,
        //            StreetAddress = model.StreetAddress,
        //            Zip = model.Zip,
        //            ApplicationId = userId,
        //            DaysOfTheWeeks = context.DaysOfTheWeeks.First(), //default
        //            AccumulatedCharges = 0
        //        });
        //        context.SaveChanges();


        //    }
    }
}