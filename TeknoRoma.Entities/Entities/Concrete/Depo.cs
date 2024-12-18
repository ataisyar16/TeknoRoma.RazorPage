using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Depo : BaseEntity
    {
        public string DepoAdi { get; set; }
        public string SubeId { get; set; }
        public string Adres { get; set; }

        // Navigation Properties
        public Sube Sube { get; set; }
        public ICollection<Stok> Stoklar { get; set; }
        public ICollection<StokHareket> StokHareketleri { get; set; }
    }
}
