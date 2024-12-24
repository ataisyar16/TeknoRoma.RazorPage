using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class Menu : BaseEntity
    {
        public string MenuAdi { get; set; }
        public string? Page { get; set; }
        public string? Icon { get; set; }
        public string? Css { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Area { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ParentId { get; set; }
        public Menu? Parent { get; set; }
        public List<Menu>? Children { get; set; }
    }
}
