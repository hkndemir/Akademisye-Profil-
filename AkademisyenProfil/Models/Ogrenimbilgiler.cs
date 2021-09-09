using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AkademisyenProfil.Models
{
    public class Ogrenimbilgiler
    {
        [Key]
        public int ogrenimno { get; set; }
        public String arastirmaalan { get; set; }
        public String doktora { get; set; }
        public String yukseklisans { get; set; }
        public String lisans { get; set; }

        [ForeignKey("Akademisyenler")]
        public int akano { get; set; }
        public Akademisyenler Akademisyenler { get; set; }

    }
}
