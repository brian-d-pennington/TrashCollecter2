using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class DaysOfTheWeek
    {
        [Key]
        public int Id { get; set; }

        public string Weekday { get; set; }

    }
}