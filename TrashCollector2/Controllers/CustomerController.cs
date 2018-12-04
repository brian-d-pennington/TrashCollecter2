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
            return View();
        }

       
    }
}