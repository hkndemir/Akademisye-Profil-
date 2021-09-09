using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AkademisyenProfil.Models
{
    public class Hakemlikler
    {
        [Key]
        public int hakemno { get; set; }
        public String hakemad { get; set; }
        [ForeignKey("Akademisyenler")]
        public int akano { get; set; }
        public Akademisyenler Akademisyenler { get; set; }
    }
}
