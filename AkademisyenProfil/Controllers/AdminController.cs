using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AkademisyenProfil.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// Burası admin panelimizi controller kısmı listeleme ekleme silme ve  file upload kısımları fonksiyonları burada bulunmaktadır 
namespace AkademisyenProfil.Controllers
{
    public class AdminController : Controller
    {
        string fileName;
        context liste = new context();
        context liste1 = new context();
        //Authorize giriş yapmadan bu sayfaya erişmemek için koyuldu
        [Authorize]
        public IActionResult Index()
        {   
            var aka = liste.akademisyenlers.ToList();
            ViewBag.aka = aka.Count();
            var fak = liste.fakultelers.ToList();
            ViewBag.fak = fak.Count();
            var bol = liste.bolumlers.ToList();
            ViewBag.bol = bol.Count();


            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult fakulteekle()
        {
            return View();
        }
        //Bu kısımda file upload kodu var ve bu kod 3 kısımda yer alıyor bölüm,akademisyen eklemede ve burada yer alıyor -
        //burada resimleri ilgili klasörde ekliyip ve yolunu veritabanına kayıt edip orada dinamik bir şekilde çekiyoruz
        [HttpPost]
        public IActionResult fakulteekle(IFormFile fakultelogo, [FromServices] IHostingEnvironment oHostingEnvironment, Fakulteler f)
        {
            fileName = $"{oHostingEnvironment.WebRootPath}/Image/Fakultelogo/{fakultelogo.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                fakultelogo.CopyTo(fileStream);
                fileStream.Flush();
                int ilk = fileName.IndexOf("/");
                f.fakultelogo = fileName.Substring(ilk);
            }
            liste.fakultelers.Add(f);
            liste.SaveChanges();
            return RedirectToAction("fakulteler");
        }
        [Authorize]
        [HttpGet]
        public IActionResult bolumekle()
        {
            List<SelectListItem> degerler = (from i in liste1.fakultelers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text =  i.fakultead,
                                                 Value = i.fakulteno.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult bolumekle(IFormFile bollogo, [FromServices] IHostingEnvironment oHostingEnvironment, Bolumler b)
        {
            fileName = $"{oHostingEnvironment.WebRootPath}/Image/Bolumlogo/{bollogo.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                bollogo.CopyTo(fileStream);
                fileStream.Flush();
                int ilk = fileName.IndexOf("/");
                b.bollogo = fileName.Substring(ilk);
            }
            var fak = liste1.fakultelers.Where(m => m.fakulteno == b.Fakulteler.fakulteno).FirstOrDefault();
            b.Fakulteler = fak;
            liste1.bolumlers.Add(b);
            liste1.SaveChanges();
            return RedirectToAction("bolumler");
        }
        [Authorize]
        [HttpGet]
        public IActionResult akademisyenekle()
        {
            List<SelectListItem> degerler = (from i in liste1.bolumlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.bolumad,
                                                 Value = i.bolumno.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
            
        }
        [HttpPost]
        public IActionResult akademisyenekle(IFormFile akafoto, [FromServices] IHostingEnvironment oHostingEnvironment, Akademisyenler a)
        {

            fileName = $"{oHostingEnvironment.WebRootPath}/Image/Akademisyenfoto/{akafoto.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                akafoto.CopyTo(fileStream);
                fileStream.Flush();
                int  ilk = fileName.IndexOf("/");              
                a.akafoto = fileName.Substring(ilk);
            }

            var bol = liste1.bolumlers.Where(m => m.bolumno == a.Bolumler.bolumno).FirstOrDefault();
            a.Bolumler = bol;
            liste1.akademisyenlers.Add(a);
            liste1.SaveChanges();
            return RedirectToAction("akademisyenler");
        }
        [Authorize]
        [HttpGet]
        public IActionResult makaleekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult makaleekle(Makaleler ma)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == ma.Akademisyenler.akano).FirstOrDefault();
            ma.Akademisyenler = aka;
            liste1.makalelers.Add(ma);
            liste1.SaveChanges();
            return RedirectToAction("makaleler");
        }
        [Authorize]
        [HttpGet]
        public IActionResult projeekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult projeekle(Projeler p)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == p.Akademisyenler.akano).FirstOrDefault();
            p.Akademisyenler = aka;
            liste1.projelers.Add(p);
            liste1.SaveChanges();
            return RedirectToAction("projeler");
        }
        [Authorize]
        [HttpGet]
        public IActionResult bildiriekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public IActionResult bildiriekle(Bildiriler bi)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == bi.Akademisyenler.akano).FirstOrDefault();
            bi.Akademisyenler = aka;
            liste1.bildirilers.Add(bi);
            liste1.SaveChanges();
            return RedirectToAction("Bildiriler");

        }
        [Authorize]
        [HttpGet]
        public IActionResult kitapekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public IActionResult kitapekle(Kitaplar k)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == k.Akademisyenler.akano).FirstOrDefault();
            k.Akademisyenler = aka;
            liste1.kitaplars.Add(k);
            liste1.SaveChanges();
            return RedirectToAction("Kitaplar");
        }
        [Authorize]
        [HttpGet]
        public IActionResult dersekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public IActionResult dersekle(Dersler d)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == d.Akademisyenler.akano).FirstOrDefault();
            d.Akademisyenler = aka;
            liste1.derslers.Add(d);
            liste1.SaveChanges();
            return RedirectToAction("Dersler");

        }
        [Authorize]
        [HttpGet]
        public IActionResult odulekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public IActionResult odulekle(Oduller o)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == o.Akademisyenler.akano).FirstOrDefault();
            o.Akademisyenler = aka;
            liste1.odullers.Add(o);
            liste1.SaveChanges();
            return RedirectToAction("Oduller");

        }
        [Authorize]
        [HttpGet]
        public IActionResult gorevekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public IActionResult gorevekle(Gorevler g)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == g.Akademisyenler.akano).FirstOrDefault();
            g.Akademisyenler = aka;
            liste1.gorevlers.Add(g);
            liste1.SaveChanges();
            return RedirectToAction("Gorevler");

        }
        [Authorize]
        [HttpGet]
        public IActionResult hakemlikekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult hakemlikekle(Hakemlikler hak)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == hak.Akademisyenler.akano).FirstOrDefault();
            hak.Akademisyenler = aka;
            liste1.hakemliklers.Add(hak);
            liste1.SaveChanges();
            return RedirectToAction("Gorevler");

        }
        [Authorize]
        [HttpGet]
        public IActionResult sertifikaekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult sertifikaekle(Sertifikalar s)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == s.Akademisyenler.akano).FirstOrDefault();
            s.Akademisyenler = aka;
            liste1.sertifikalars.Add(s);
            liste1.SaveChanges();
            return RedirectToAction("Sertifikalar");

        }
        [Authorize]
        [HttpGet]
        public IActionResult ogrenimekle()
        {
            List<SelectListItem> degerler = (from i in liste1.akademisyenlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.akaad,
                                                 Value = i.akano.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult ogrenimekle(Ogrenimbilgiler ogrenim)
        {
            var aka = liste1.akademisyenlers.Where(m => m.akano == ogrenim.Akademisyenler.akano).FirstOrDefault();
            ogrenim.Akademisyenler = aka;
            liste1.ogrenimbilgilers.Add(ogrenim);
            liste1.SaveChanges();
            return RedirectToAction("Ogrenimler");

        }
        [Authorize]
        public IActionResult akademisyenler()
        {
            
            var aka = liste.akademisyenlers.ToList();
            var bol = liste.bolumlers.ToList();
            return View(aka);

        }
        [Authorize]
        public IActionResult bolumler()
        {
            var bol = liste.bolumlers.ToList();
            var fak = liste.fakultelers.ToList();
            return View(bol);

        }
        [Authorize]
        public IActionResult fakulteler()
        {
            var fak = liste.fakultelers.ToList();
            return View(fak);
        }
        [Authorize]
        public IActionResult makaleler()
        {
            var mak = liste.makalelers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(mak);
        }
        [Authorize]
        public IActionResult projeler()
        {
            var proje = liste.projelers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(proje);
        }
        [Authorize]
        public IActionResult bildiriler()
        {
            var bildiri = liste.bildirilers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(bildiri);
        }
        [Authorize]
        public IActionResult kitaplar()
        {
            var kitap = liste.kitaplars.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(kitap);
        }
        [Authorize]
        public IActionResult dersler()
        {
            var ders = liste.derslers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(ders);
        }
        [Authorize]
        public IActionResult oduller()
        {
            var odul = liste.odullers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(odul);
        }
        [Authorize]
        public IActionResult gorevler()
        {
            var gorev = liste.gorevlers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(gorev);
        }
        [Authorize]
        public IActionResult hakemlikler()
        {
            var hakemlik = liste.hakemliklers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(hakemlik);
        }
        [Authorize]
        public IActionResult sertifikalar()
        {
            var sertifika = liste.sertifikalars.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(sertifika);
        }
        [Authorize]
        public IActionResult ogrenimler()
        {
            var ogr = liste.ogrenimbilgilers.ToList();
            var aka = liste.akademisyenlers.ToList();
            return View(ogr);
        }

        public IActionResult AkaSil(int id)
        {
            var aka = liste.akademisyenlers.Find(id);
            liste.akademisyenlers.Remove(aka);
            liste.SaveChanges();
            return RedirectToAction("akademisyenler");
        }
         public IActionResult BolumSil(int id)
        {
            var bolum = liste.bolumlers.Find(id);
            liste.bolumlers.Remove(bolum);
            liste.SaveChanges();
            return RedirectToAction("bolumler");
        }

        public IActionResult FakulteSil(int id)
        {
            var fakulte = liste.fakultelers.Find(id);
            liste.fakultelers.Remove(fakulte);
            liste.SaveChanges();
            return RedirectToAction("fakulteler");
        }

        public IActionResult OgrenimSil(int id)
        {
            var ogrenim = liste.ogrenimbilgilers.Find(id);
            liste.ogrenimbilgilers.Remove(ogrenim);
            liste.SaveChanges();
            return RedirectToAction("ogrenimler");
        }

        public IActionResult MakaleSil(int id)
        {
            var makale = liste.makalelers.Find(id);
            liste.makalelers.Remove(makale);
            liste.SaveChanges();
            return RedirectToAction("makaleler");
        }

        public IActionResult ProjeSil(int id)
        {
            var proje = liste.projelers.Find(id);
            liste.projelers.Remove(proje);
            liste.SaveChanges();
            return RedirectToAction("projeler");
        }

        public IActionResult BildiriSil(int id)
        {
            var bildiri = liste.bildirilers.Find(id);
            liste.bildirilers.Remove(bildiri);
            liste.SaveChanges();
            return RedirectToAction("bildiriler");
        }

        public IActionResult KitapSil(int id)
        {
            var kitap = liste.kitaplars.Find(id);
            liste.kitaplars.Remove(kitap);
            liste.SaveChanges();
            return RedirectToAction("kitaplar");
        }

        public IActionResult DersSil(int id)
        {
            var ders = liste.derslers.Find(id);
            liste.derslers.Remove(ders);
            liste.SaveChanges();
            return RedirectToAction("dersler");
        }

        public IActionResult OdulSil(int id)
        {
            var odul = liste.odullers.Find(id);
            liste.odullers.Remove(odul);
            liste.SaveChanges();
            return RedirectToAction("oduller");
        }

        public IActionResult GorevSil(int id)
        {
            var gorev = liste.gorevlers.Find(id);
            liste.gorevlers.Remove(gorev);
            liste.SaveChanges();
            return RedirectToAction("gorevler");
        }

        public IActionResult HakemlikSil(int id)
        {
            var hakemlik = liste.hakemliklers.Find(id);
            liste.hakemliklers.Remove(hakemlik);
            liste.SaveChanges();
            return RedirectToAction("hakemlikler");
        }

        public IActionResult SertifikaSil(int id)
        {
            var sertifika = liste.sertifikalars.Find(id);
            liste.sertifikalars.Remove(sertifika);
            liste.SaveChanges();
            return RedirectToAction("sertifikalar");
        }
    }
}

