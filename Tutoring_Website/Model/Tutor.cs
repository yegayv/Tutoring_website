using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring_Website.Model
{
    public class Tutor
    {
        [Key]
        public int tutor_id { get; set; }

        [Required]
        public string tutor_name { get; set; }
        public string tutor_description { get; set; }
        public string tutor_subjects { get; set; }
        public int tutor_rate { get; set; }
        public string tutor_img { get; set; }
        public double tutor_rating { get; set; }
        public DateTime tutor_date_joined { get; set; }
    }
}
