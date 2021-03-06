﻿using System;
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
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("DaysOfTheWeek")]
        [Display(Name = "Weekly Pickup Day")]
        public int WeekdayID { get; set; }
        public DaysOfTheWeek DaysOfTheWeek { get; set; }

        
        [Display(Name = "One Time Pickup")]
        public DateTime? SpecialRequest { get; set; }
        [Display(Name = "Suspend Service On")]
        public DateTime? SuspendStartDate { get; set; }
        [Display(Name = "Resume Service By")]
        public DateTime? ResumeServiceDate { get; set; }
        [Display(Name = "Pending Charges")]
        public double AccumulatedCharges { get; set; }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public int Day2 { get; set; }
        public int Month2 { get; set; }
        public int Year2 { get; set; }
        public int Day3 { get; set; }
        public int Month3 { get; set; }
        public int Year3 { get; set; }
        public IEnumerable<DaysOfTheWeek> DaysOfTheWeeks { get; set; }
        public IEnumerable<DaysOfTheWeek> Days { get; set; }

    }

    
}