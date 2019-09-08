using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABIY_One.Models
{
    public class FeedbackViewModel
    {
        [Required]
        public string Comment { get; set; }
        //[Required(ErrorMessage = "Input Your Name")]

        public string FullName { get; set; }

        //[Required(ErrorMessage = "Input valid Email")]
        //[Display(Name ="User")]
        //[ForeignKey("Product")]
        //public int ItemCode { get; set; }
        public DateTime date { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage = "Rate our service")]
        public int? Select { get; set; }


        public List<Answer> Answers { get; set; }
        //public virtual Product Product { get; set; }



    }
}