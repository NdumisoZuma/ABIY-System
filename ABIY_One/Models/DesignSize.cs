using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABIY_One.Models
{
    public class DesignSize
    {
        [Key]
        public int DsizeId { get; set; }
        [Display(Name = "Print Size")]
        public string SizeName { get; set; }
        public virtual ICollection<UploadDesign> uploads { get; set; }
    }
}