﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Servis
{
    public class Islem
    {
        [Key]
        public int IslemId { get; set; }
        public int IsEmriId { get; set; }
        public string IslemAd { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal AraToplam { get; set; }
        public virtual IsEmri IsEmri { get; set; }

    }
}
