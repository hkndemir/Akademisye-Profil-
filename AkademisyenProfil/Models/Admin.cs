using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademisyenProfil.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string Kullanici { get; set; }
        public string Sifre { get; set; }
    }
}
