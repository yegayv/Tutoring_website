using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring_Website.Model
{
    public class Product
    {
        public int product_id { get; set; }
        public string vendor_id { get; set; }
        public string product_name { get; set; }
        public ProductInfo product_info { get; set; }
    }
}
