using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class SatisDetay : BaseEntity
    {
        public string SatisId { get; set; }
        public string StokId { get; set; }
        public int? Miktar { get; set; }
        public double BirimFiyat { get; set; }

        // Navigation Properties
        public Satis Satis { get; set; }
        public Stok Stok { get; set; }
    }
}
