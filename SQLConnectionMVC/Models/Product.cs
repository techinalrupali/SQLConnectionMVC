﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLConnectionMVC.Models
{
    public class Product
    {
       [Key]
       [ScaffoldColumn(false)]

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
