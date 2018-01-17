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
                Tanitim = "Edebi kitaplar i�ermektedir"
            };
            context.Kategoriler.Add(kat);
            Kategori kat2 = new Kategori()
            {
                Baslik = "Felsefe",
                Tanitim = "Felsefi kitaplar i�ermektedir"
            };
            context.Kategoriler.Add(kat2);
            Kategori kat3 = new Kategori()
            {
                Baslik = "Ara�t�rma-Tarih",
                Tanitim = "Ara�t�rma-Tarih kitaplar� i�ermektedir"
            };
            context.Kategoriler.Add(kat3);
            Kategori kat4 = new Kategori()
            {
                Baslik = "Din-Mitoloji",
                Tanitim = "Din-Mitoloji kitaplar� i�ermektedir"
            };
            context.Kategoriler.Add(kat4);
            Kategori kat5 = new Kategori()
            {
                Baslik = "Bilim",
                Tanitim = "Bilim kitaplar� i�ermektedir"
            };
            context.Kategoriler.Add(kat5);
            Kategori kat6 = new Kategori()
            {
                Baslik = "�ocuk ve Gen�lik",
                Tanitim = "�ocuk ve gen�lik kitaplar� i�ermektedir"
            };
            context.Kategoriler.Add(kat6);
            Kategori kat7 = new Kategori()
            {
                Baslik = "Programlama",
                Tanitim = "Programlama kitaplar� i�ermektedir"
            };
            context.Kategoriler.Add(kat7);
            Kategori kat8 = new Kategori()
            {
                Baslik = "Ders Kitaplar�",
                Tanitim = "Ders Kitaplar� i�ermektedir"
            };
            context.Kategoriler.Add(kat8);
            context.SaveChanges();

            Not not = new Not()
            {
                Baslik = "Bir Askerin An�lar�",
                Icerik = "Kitap,Alman General Heinz Guderian'�n 2.D�nya Sava��ndaki an�lar�n� anlatmaktad�r.Yazar sava�tan �nce Panzer Doktrini ad�yla bir kitap yay�nlam��t�r.Kitap Z�rl� birliklerin kullan�m�ndan ve �neminden bahsetmektedir.",
                Kategoriler = kat3,
                BegeniSayisi = 22,
            };
            kat3.Notlar.Add(not);
            context.SaveChanges();

            
        }
    }
}
