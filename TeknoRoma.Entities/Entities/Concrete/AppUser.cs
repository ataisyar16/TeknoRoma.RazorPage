using Microsoft.AspNetCore.Identity;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string TcNo { get; set; } // Personel ile ilişki (Opsiyonel)
        public string UserType { get; set; } = "Customer"; // Varsayılan değer
                                                           // "Customer" veya "Employee" gibi değerler alabilir

        // Navigation Property
        public Personel Personel { get; set; }
        public ICollection<KullaniciYorum> Yorumlar { get; set; } = new List<KullaniciYorum>();

    }
}
