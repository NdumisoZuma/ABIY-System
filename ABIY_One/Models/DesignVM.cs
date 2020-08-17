using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABIY_One.Models
{
    public class DesignVM
    {
        [Key]

        public int DVMid { get; set; }

        [ForeignKey("design")]
        [DisplayName("Design Name")]
        public int DId { get; set; }
        [ForeignKey("area2")]
        public int DesignAreaId { get; set; }
        [ForeignKey("size")]
        public int DesignSizeId { get; set; }
        public virtual Design design { get; set; }
        public virtual DesignArea area2 { get; set; }
        public virtual DesignSize size { get; set; }


    }
}