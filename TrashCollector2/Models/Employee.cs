using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Route { get; set; } // zip code driver assigned

        //[ForeignKey]

    }
}