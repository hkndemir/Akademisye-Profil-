using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademisyenProfil.Models
{
    public class Fakulteler
    {
        [Key]
        public int fakulteno { get; set; }

        public String fakultelogo { get; set; }
        public String fakultead { get; set; }
    }
}
