namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TrashCollector2.Models.ApplicationDbContext";
        }

        protected override void Seed(TrashCollector2.Models.ApplicationDbContext context)
        {

            //context.Employees.AddOrUpdate(
            //   new Models.Employee { Email = "jitsche@gmail.com", EmployeeNumber = "e5452", Route = "53207" },
            //   new Models.Employee { Email = "hjazz@yahoo.com", EmployeeNumber = "e5451", Route = "53208" },
            //   new Models.Employee { Email = "mhunt@aol.com", EmployeeNumber = "e5450", Route = "53204" });

            // employees seeded with employeesSeeded migration

        }
    }
}
