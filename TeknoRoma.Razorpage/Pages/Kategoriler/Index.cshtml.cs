using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kategoriler
{
    public class IndexModel(IManager<Kategori> KategoriManager) : PageModel
    {
        public ICollection<Kategori> Kategoriler { get; set; }

        public async Task OnGet()
        {
            Kategoriler = await KategoriManager.GetAllAsync(default);
        }
    }
}
