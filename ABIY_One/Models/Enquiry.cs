using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ABIY_One.Models
{
    public class Enquiry
    {
        [Key]
        public int Enq_Id { get; set; }
        [StringLength(100)]
        [Display(Name = "Name & Surname")]
        public string FullName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}