using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector2.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string StreetAddress { get; set; }
        public string Zip { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("DaysOfTheWeeks")]
        public int WeekdayID { get; set; }

        public DaysOfTheWeek DaysOfTheWeeks { get; set; }

        public DateTime SpecialRequest { get; set; }

        public DateTime SuspendStartDate { get; set; }

        public DateTime ResumeServiceDate { get; set; }

        public double AccumulatedCharges { get; set; }

    }

    
}