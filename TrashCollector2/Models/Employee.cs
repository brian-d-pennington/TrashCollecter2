using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        [Display(Name= "Employee Number")]
        public string EmployeeNumber { get; set; }
        public string Route { get; set; } // zip code driver assigned

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}