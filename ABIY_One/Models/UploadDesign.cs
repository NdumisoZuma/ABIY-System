﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABIY_One.Models
{
    public class UploadDesign
    {
        [Key]
        public int UploadId { get; set; }
        public string UploadName { get; set; }
        public byte[] PrintImage { get; set; }
        [ForeignKey("designSize")]
        public int PrintSizeId { get; set; }
        [ForeignKey("designArea")]
        public int PrintAreaId { get; set; }
        public virtual DesignSize designSize { get; set; }
        public virtual DesignArea designArea { get; set; }
    }
}