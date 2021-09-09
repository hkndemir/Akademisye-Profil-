using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AkademisyenProfil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//Burası bizim kullanıcı yani insanların göreceği kısım ana sayfa olarak fakülte listesi yaptık ve ondan sonra seçilen verinin id değerini alıp ilgili sayfalarda listeleme yapıyoruz.
namespace AkademisyenProfil.Controllers
{
    public class AnaSayfaController : Controller
    {
        context liste = new context();
       
        public IActionResult AnaSayfa()
        {
            var fakulte = liste.fakultelers.ToList();
            return View(fakulte);
        }

        public IActionResult Bolumler(int id)
        {
            var bolum = liste.bolumlers.Where(x => x.fakulteno == id).ToList();
            var fkl = liste.fakultelers.Where(x => x.fakulteno == id).Select(y => y.fakultead).FirstOrDefault();
            ViewBag.fkl = fkl;
            return View(bolum);
        }

        public IActionResult Akademisyenler(int id)
        {
            var aka = liste.akademisyenlers.Where(x => x.bolumno == id).ToList();
            var blm = liste.bolumlers.Where(x => x.bolumno == id).Select(y => y.bolumad).FirstOrDefault();
            ViewBag.blm = blm;
            return View(aka);
        }


        public IActionResult Profil(int id)
        {

            var ogr = liste.ogrenimbilgilers.Where(x => x.akano == id).ToList();

            var aka = liste.akademisyenlers.Where(x => x.akano == id).ToList();
            ViewBag.aka = aka;

            var mkl = liste.makalelers.Where(x => x.akano == id).ToList();
            ViewBag.mkl = mkl;
            var prj = liste.projelers.Where(x => x.akano == id).ToList();
            ViewBag.prj = prj;


            var blr = liste.bildirilers.Where(x => x.akano == id).ToList();
            ViewBag.blr = blr;

            var blr1 = liste.bildirilers.Where(x => x.akano == id).Select(y => y.ulusal).ToList();
            ViewBag.blr1 = blr1;


            var drs = liste.derslers.Where(x => x.akano == id).ToList();
            ViewBag.drs = drs;
            var grv = liste.gorevlers.Where(x => x.akano == id).ToList();
            ViewBag.grv = grv;
            var hkm = liste.hakemliklers.Where(x => x.akano == id).ToList();
            ViewBag.hkm = hkm;
            var ktb = liste.kitaplars.Where(x => x.akano == id).ToList();
            ViewBag.ktb = ktb;

            var odl = liste.odullers.Where(x => x.akano == id).ToList();
            ViewBag.odl = odl;
            var srt = liste.sertifikalars.Where(x => x.akano == id).ToList();
            ViewBag.srt = srt;
            return View(ogr);

        }
    }
}
