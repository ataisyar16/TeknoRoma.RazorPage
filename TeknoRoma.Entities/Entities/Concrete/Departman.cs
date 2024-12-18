using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Departman : BaseEntity
    {
        public string DepartmanAdi { get; set; }
        public string UstId { get; set; } // Parent Departman ID

        // Navigation Properties
        public ICollection<Personel> Personeller { get; set; }
        public Departman UstDepartman { get; set; }
    }
}
