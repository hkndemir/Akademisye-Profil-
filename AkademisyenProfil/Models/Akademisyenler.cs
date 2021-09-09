using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//Projeye ilk olarak model kısımları ile başlandı ve modeller bu yöntem ile yapıldı bağlı tablolar foreignKey ile bağlandı 
namespace AkademisyenProfil.Models
{
    public class Akademisyenler
    {
        [Key]
        public int akano { get; set; }
        public String akafoto { get; set; }
        public String akaunvan { get; set; }
        public String akaad { get; set; }       
        public String akaemail { get; set; }
        public String akatel { get; set; }

        [ForeignKey("Bolumler")]
        public int bolumno { get; set; }
        public Bolumler Bolumler { get; set; }
       
    }
}
