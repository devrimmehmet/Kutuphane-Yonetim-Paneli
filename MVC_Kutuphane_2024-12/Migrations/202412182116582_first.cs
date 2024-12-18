namespace Devrekani_Sehitler_Kutuphanesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kitaps", "KategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.Kitaps", "YazarId", "dbo.Yazars");
            DropForeignKey("dbo.Harekets", "KitapId", "dbo.Kitaps");
            DropForeignKey("dbo.Harekets", "Personel_Id", "dbo.Personels");
            DropForeignKey("dbo.Harekets", "PersonelId", "dbo.Personels");
            DropForeignKey("dbo.Harekets", "UyeId", "dbo.Uyes");
            DropForeignKey("dbo.Cezalars", "HareketId", "dbo.Harekets");
            DropForeignKey("dbo.Cezalars", "UyeId", "dbo.Uyes");
            DropIndex("dbo.Cezalars", new[] { "UyeId" });
            DropIndex("dbo.Cezalars", new[] { "HareketId" });
            DropIndex("dbo.Harekets", new[] { "KitapId" });
            DropIndex("dbo.Harekets", new[] { "UyeId" });
            DropIndex("dbo.Harekets", new[] { "PersonelId" });
            DropIndex("dbo.Harekets", new[] { "Personel_Id" });
            DropIndex("dbo.Kitaps", new[] { "KategoriId" });
            DropIndex("dbo.Kitaps", new[] { "YazarId" });
            CreateTable(
                "dbo.TBL_CEZALAR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UYE = c.Int(),
                        BASLANGIC = c.DateTime(),
                        BITIS = c.DateTime(),
                        PARA = c.Decimal(precision: 18, scale: 2),
                        HAREKET = c.Byte(),
                        TBL_HAREKET_ID = c.Byte(),
                        TBL_UYELER_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TBL_HAREKET", t => t.TBL_HAREKET_ID)
                .ForeignKey("dbo.TBL_UYELER", t => t.TBL_UYELER_ID)
                .Index(t => t.TBL_HAREKET_ID)
                .Index(t => t.TBL_UYELER_ID);
            
            CreateTable(
                "dbo.TBL_HAREKET",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        KITAP = c.Int(),
                        UYE = c.Int(),
                        PERSONEL = c.Byte(),
                        ALISTARIHI = c.DateTime(),
                        IADETARIHI = c.DateTime(),
                        ISLEMDURUM = c.Boolean(),
                        UYEGETIRTARIH = c.DateTime(),
                        TBL_KITAP_ID = c.Int(),
                        TBL_PERSONEL_ID = c.Byte(),
                        TBL_UYELER_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TBL_KITAP", t => t.TBL_KITAP_ID)
                .ForeignKey("dbo.TBL_PERSONEL", t => t.TBL_PERSONEL_ID)
                .ForeignKey("dbo.TBL_UYELER", t => t.TBL_UYELER_ID)
                .Index(t => t.TBL_KITAP_ID)
                .Index(t => t.TBL_PERSONEL_ID)
                .Index(t => t.TBL_UYELER_ID);
            
            CreateTable(
                "dbo.TBL_KITAP",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(),
                        KATEGORI = c.Byte(),
                        YAZAR = c.Int(),
                        BASKIYILI = c.String(),
                        YAYINEVI = c.String(),
                        SAYFA = c.String(),
                        DURUM = c.Boolean(),
                        KITAPRESIM = c.String(),
                        TBL_KATEGORI_ID = c.Byte(),
                        TBL_YAZAR_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TBL_KATEGORI", t => t.TBL_KATEGORI_ID)
                .ForeignKey("dbo.TBL_YAZAR", t => t.TBL_YAZAR_ID)
                .Index(t => t.TBL_KATEGORI_ID)
                .Index(t => t.TBL_YAZAR_ID);
            
            CreateTable(
                "dbo.TBL_KATEGORI",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        AD = c.String(),
                        DURUM = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_YAZAR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(),
                        SOYAD = c.String(),
                        DETAY = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_PERSONEL",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        PERSONEL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_UYELER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(),
                        SOYAD = c.String(),
                        MAIL = c.String(),
                        KULLANICIADI = c.String(),
                        SIFRE = c.String(),
                        FOTOGRAF = c.String(),
                        TELEFON = c.String(),
                        OKUL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_DUYURULAR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KATEGORI = c.String(),
                        ICERIK = c.String(),
                        TARIH = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_HAKKIMIZDA",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        ACIKLAMA = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_ILETISIM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(),
                        MAIL = c.String(),
                        TELEFON = c.String(),
                        KONU = c.String(),
                        MESAJ = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_KASA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AY = c.String(),
                        TUTAR = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_MESAJLAR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GONDEREN = c.String(),
                        ALICI = c.String(),
                        KONU = c.String(),
                        ICERIK = c.String(),
                        TARIH = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Cezalars");
            DropTable("dbo.Harekets");
            DropTable("dbo.Kitaps");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Yazars");
            DropTable("dbo.Personels");
            DropTable("dbo.Uyes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Uyes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Mail = c.String(),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                        Fotograf = c.String(),
                        Telefon = c.String(),
                        Okul = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        PersonelAdi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yazars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Detay = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Ad = c.String(),
                        Durum = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        KategoriId = c.Byte(),
                        YazarId = c.Int(),
                        BaskiYili = c.String(),
                        Yayinevi = c.String(),
                        Sayfa = c.String(),
                        Durum = c.Boolean(),
                        KitapResim = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Harekets",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        KitapId = c.Int(),
                        UyeId = c.Int(),
                        PersonelId = c.Byte(),
                        AlisTarihi = c.DateTime(),
                        IadeTarihi = c.DateTime(),
                        IslemDurum = c.Boolean(),
                        UyeGetirTarih = c.DateTime(),
                        Personel_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cezalars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(),
                        Baslangic = c.DateTime(),
                        Bitis = c.DateTime(),
                        Para = c.Decimal(precision: 18, scale: 2),
                        HareketId = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TBL_HAREKET", "TBL_UYELER_ID", "dbo.TBL_UYELER");
            DropForeignKey("dbo.TBL_CEZALAR", "TBL_UYELER_ID", "dbo.TBL_UYELER");
            DropForeignKey("dbo.TBL_HAREKET", "TBL_PERSONEL_ID", "dbo.TBL_PERSONEL");
            DropForeignKey("dbo.TBL_KITAP", "TBL_YAZAR_ID", "dbo.TBL_YAZAR");
            DropForeignKey("dbo.TBL_KITAP", "TBL_KATEGORI_ID", "dbo.TBL_KATEGORI");
            DropForeignKey("dbo.TBL_HAREKET", "TBL_KITAP_ID", "dbo.TBL_KITAP");
            DropForeignKey("dbo.TBL_CEZALAR", "TBL_HAREKET_ID", "dbo.TBL_HAREKET");
            DropIndex("dbo.TBL_KITAP", new[] { "TBL_YAZAR_ID" });
            DropIndex("dbo.TBL_KITAP", new[] { "TBL_KATEGORI_ID" });
            DropIndex("dbo.TBL_HAREKET", new[] { "TBL_UYELER_ID" });
            DropIndex("dbo.TBL_HAREKET", new[] { "TBL_PERSONEL_ID" });
            DropIndex("dbo.TBL_HAREKET", new[] { "TBL_KITAP_ID" });
            DropIndex("dbo.TBL_CEZALAR", new[] { "TBL_UYELER_ID" });
            DropIndex("dbo.TBL_CEZALAR", new[] { "TBL_HAREKET_ID" });
            DropTable("dbo.TBL_MESAJLAR");
            DropTable("dbo.TBL_KASA");
            DropTable("dbo.TBL_ILETISIM");
            DropTable("dbo.TBL_HAKKIMIZDA");
            DropTable("dbo.TBL_DUYURULAR");
            DropTable("dbo.TBL_UYELER");
            DropTable("dbo.TBL_PERSONEL");
            DropTable("dbo.TBL_YAZAR");
            DropTable("dbo.TBL_KATEGORI");
            DropTable("dbo.TBL_KITAP");
            DropTable("dbo.TBL_HAREKET");
            DropTable("dbo.TBL_CEZALAR");
            CreateIndex("dbo.Kitaps", "YazarId");
            CreateIndex("dbo.Kitaps", "KategoriId");
            CreateIndex("dbo.Harekets", "Personel_Id");
            CreateIndex("dbo.Harekets", "PersonelId");
            CreateIndex("dbo.Harekets", "UyeId");
            CreateIndex("dbo.Harekets", "KitapId");
            CreateIndex("dbo.Cezalars", "HareketId");
            CreateIndex("dbo.Cezalars", "UyeId");
            AddForeignKey("dbo.Cezalars", "UyeId", "dbo.Uyes", "Id");
            AddForeignKey("dbo.Cezalars", "HareketId", "dbo.Harekets", "Id");
            AddForeignKey("dbo.Harekets", "UyeId", "dbo.Uyes", "Id");
            AddForeignKey("dbo.Harekets", "PersonelId", "dbo.Personels", "Id");
            AddForeignKey("dbo.Harekets", "Personel_Id", "dbo.Personels", "Id");
            AddForeignKey("dbo.Harekets", "KitapId", "dbo.Kitaps", "Id");
            AddForeignKey("dbo.Kitaps", "YazarId", "dbo.Yazars", "Id");
            AddForeignKey("dbo.Kitaps", "KategoriId", "dbo.Kategoris", "Id");
        }
    }
}
