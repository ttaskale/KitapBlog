namespace DAL.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.BlogContext context)
        {
           

            Kategori kat = new Kategori()
            {
                Baslik = "Edebiyat",
                Tanitim = "Edebi kitaplar içermektedir"
            };
            context.Kategoriler.Add(kat);
            Kategori kat2 = new Kategori()
            {
                Baslik = "Felsefe",
                Tanitim = "Felsefi kitaplar içermektedir"
            };
            context.Kategoriler.Add(kat2);
            Kategori kat3 = new Kategori()
            {
                Baslik = "Araþtýrma-Tarih",
                Tanitim = "Araþtýrma-Tarih kitaplarý içermektedir"
            };
            context.Kategoriler.Add(kat3);
            Kategori kat4 = new Kategori()
            {
                Baslik = "Din-Mitoloji",
                Tanitim = "Din-Mitoloji kitaplarý içermektedir"
            };
            context.Kategoriler.Add(kat4);
            Kategori kat5 = new Kategori()
            {
                Baslik = "Bilim",
                Tanitim = "Bilim kitaplarý içermektedir"
            };
            context.Kategoriler.Add(kat5);
            Kategori kat6 = new Kategori()
            {
                Baslik = "Çocuk ve Gençlik",
                Tanitim = "Çocuk ve gençlik kitaplarý içermektedir"
            };
            context.Kategoriler.Add(kat6);
            Kategori kat7 = new Kategori()
            {
                Baslik = "Programlama",
                Tanitim = "Programlama kitaplarý içermektedir"
            };
            context.Kategoriler.Add(kat7);
            Kategori kat8 = new Kategori()
            {
                Baslik = "Ders Kitaplarý",
                Tanitim = "Ders Kitaplarý içermektedir"
            };
            context.Kategoriler.Add(kat8);
            context.SaveChanges();

            Not not = new Not()
            {
                Baslik = "Bir Askerin Anýlarý",
                Icerik = "Kitap,Alman General Heinz Guderian'ýn 2.Dünya Savaþýndaki anýlarýný anlatmaktadýr.Yazar savaþtan önce Panzer Doktrini adýyla bir kitap yayýnlamýþtýr.Kitap Zýrlý birliklerin kullanýmýndan ve öneminden bahsetmektedir.",
                Kategoriler = kat3,
                BegeniSayisi = 22,
            };
            kat3.Notlar.Add(not);
            context.SaveChanges();

            
        }
    }
}
