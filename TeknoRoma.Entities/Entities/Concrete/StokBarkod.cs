using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class StokBarkod : BaseEntity
    {
        public string StokId { get; set; }
        public string? Barkod { get; set; }

        // Navigation Properties
        public Stok Stok { get; set; }
    }
}
