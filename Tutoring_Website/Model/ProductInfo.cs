using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring_Website.Model
{
    public class ProductInfo
    {
      
        public int product_id { get; set; }
        public string product_description { get; set; }
        public int product_price { get; set; }
        public string product_img { get; set; }
        public double product_rating { get; set; }
        public DateTime product_date { get; set; }
        public int product_rating_count { get; set; }
    }
}
