using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABIY_One.Models
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Feed_ID { get; set; }
        [Required]
        [Display(Name = "Ratings (1-4)")]
        public int? Answer { get; set; }
        //[ForeignKey ("ApplicationUser")]
        //public string Id { get; set; }
        //[ForeignKey("Product")]
        //public int ItemCode { get; set; }
        [Required]
        [StringLength(500)]
        public string Comment { get; set; }
        [StringLength(100)]
        [Display(Name = "Prouct Name")]

        public string FullName { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [StringLength(225)]
        public string Email { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }
        // public virtual Product Product { get; set; }


    }
}