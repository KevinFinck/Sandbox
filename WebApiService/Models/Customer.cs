using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public String Country { get; set; }
    }
}