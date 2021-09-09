using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AkademisyenProfil.Models
{
    public class Bolumler
    {
        [Key]
        public int bolumno { get; set; }
        public String bollogo { get; set; }
        public String bolumad { get; set; }

        [ForeignKey("Fakulteler")]
        public int fakulteno { get; set; }
        public Fakulteler Fakulteler { get; set; }
    }
}
