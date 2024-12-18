using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Devrekani_Sehitler_Kutuphanesi.Models.Entity
{
    public class KutuphaneContext : DbContext
    {


        public virtual DbSet<TBL_CEZALAR> TBL_CEZALAR { get; set; }
        public virtual DbSet<TBL_HAREKET> TBL_HAREKET { get; set; }
        public virtual DbSet<TBL_KASA> TBL_KASA { get; set; }
        public virtual DbSet<TBL_KATEGORI> TBL_KATEGORI { get; set; }
        public virtual DbSet<TBL_KITAP> TBL_KITAP { get; set; }
        public virtual DbSet<TBL_PERSONEL> TBL_PERSONEL { get; set; }
        public virtual DbSet<TBL_UYELER> TBL_UYELER { get; set; }
        public virtual DbSet<TBL_YAZAR> TBL_YAZAR { get; set; }
        public virtual DbSet<TBL_HAKKIMIZDA> TBL_HAKKIMIZDA { get; set; }
        public virtual DbSet<TBL_ILETISIM> TBL_ILETISIM { get; set; }
        public virtual DbSet<TBL_MESAJLAR> TBL_MESAJLAR { get; set; }
        public virtual DbSet<TBL_DUYURULAR> TBL_DUYURULAR { get; set; }

        public KutuphaneContext() : base("name=KutuphaneContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
       
        }
        public virtual ObjectResult<string> EnFazlaKitabıOlanYazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnFazlaKitabıOlanYazar");
        }
    }

}
