using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Birim : BaseEntity
    {
        public string? BirimKodu { get; set; }
        public string? Aciklama { get; set; }
        // Navigation Property
        public ICollection<Stok> Stoklar { get; set; }
    }
}
