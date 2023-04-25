﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestProject.Domain
{
    [Table("Test$")]
    public class Company
    {
        public int Id { get; set; }
        public string INN { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool IsOpen { get; set; }

    }
}
