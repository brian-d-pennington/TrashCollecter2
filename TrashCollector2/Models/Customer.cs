﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        //[ForeignKey]

    }
}