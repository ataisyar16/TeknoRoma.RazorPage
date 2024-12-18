using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Siparis : BaseEntity
    {
        public string CariId { get; set; }
        public DateTime? SiparisTarihi { get; set; }
        public string? Durum { get; set; }

        // Navigation Properties
        public Cari Cari { get; set; }
    }
}
