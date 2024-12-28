using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Stok : BaseEntity
    {
        public string StokAdi { get; set; }
        public string StokKodu { get; set; }
        public string? DepoId { get; set; }
        public int StokAdet { get; set; }

        public double Fiyat { get; set; }
        public string KategoriId { get; set; } // İlgili kategoriyi temsil eder

        // Navigation Properties
        public Depo Depo { get; set; }

        public Kategori Kategori { get; set; } // Stok bir kategoride yer alır
        public ICollection<StokBarkod> StokBarkodlari { get; set; }
        public ICollection<StokFotograf> StokFotograflari { get; set; }
        public ICollection<FaturaDetay> FaturaDetaylari { get; set; }
        public ICollection<SatisDetay> SatisDetaylari { get; set; }
        public ICollection<StokHareket> StokHareketleri { get; set; }
        public ICollection<KullaniciYorum> KullaniciYorumlari { get; set; }
        public ICollection<SiparisDetay> SiparisDetaylari { get; set; }
    }


}
