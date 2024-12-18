using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Kategori : BaseEntity
    {
        public string? KategoriAdi { get; set; }

        // Navigation Properties
        public ICollection<Stok> Stoklar { get; set; }
    }
}
