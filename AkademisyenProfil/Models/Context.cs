using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Burası biziö veritabanını olşturduğumuz ve aynı zamanda bağlantımızın yapıldığı yer aynı zamanda migration ile veri tabanını olşturduğumuz güncellediğimiz yer.
namespace AkademisyenProfil.Models
{
    public class context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-O1NCVSU; database=Akademisyen; integrated security=true");

        }
        public DbSet<Fakulteler> fakultelers { get; set; }
        public DbSet<Bolumler> bolumlers { get; set; }
        public DbSet<Akademisyenler> akademisyenlers { get; set; }
        public DbSet<Ogrenimbilgiler> ogrenimbilgilers { get; set; }
        public DbSet<Makaleler> makalelers { get; set; }
        public DbSet<Projeler> projelers { get; set; }
        public DbSet<Bildiriler> bildirilers { get; set; }
        public DbSet<Kitaplar> kitaplars { get; set; }
        public DbSet<Oduller> odullers { get; set; }
        public DbSet<Gorevler> gorevlers { get; set; }
        public DbSet<Hakemlikler> hakemliklers { get; set; }
        public DbSet<Sertifikalar> sertifikalars { get; set; }
        public DbSet<Dersler> derslers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
