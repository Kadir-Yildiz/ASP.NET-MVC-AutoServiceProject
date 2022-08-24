using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtoServis.Entities.Servis;
using OtoServis.Entities.Web;

namespace OtoServis.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Kampanya> Kampanyas { get; set; }
        public DbSet<Uygulama> Uygulamas { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<HaritaIletisim> HaritaIletisims { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
    }
}
