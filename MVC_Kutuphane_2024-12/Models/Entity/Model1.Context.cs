﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Devrekani_Sehitler_Kutuphanesi.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_Kutuphane_Entities2 : DbContext
    {
        public DB_Kutuphane_Entities2()
            : base("name=DB_Kutuphane_Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
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
    
        public virtual ObjectResult<string> EnFazlaKitabıOlanYazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnFazlaKitabıOlanYazar");
        }
    }
}
