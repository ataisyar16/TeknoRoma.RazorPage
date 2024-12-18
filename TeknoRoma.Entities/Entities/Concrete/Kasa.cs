using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Kasa : BaseEntity
    {
        public string? KasaKodu { get; set; }
        public string? SubeKodu { get; set; }
        public string DovizId { get; set; }
        public double? Bakiye { get; set; }

        // Navigation Properties
        public Doviz Doviz { get; set; }
        public ICollection<KasaHareket> KasaHareketleri { get; set; }
    }
}
