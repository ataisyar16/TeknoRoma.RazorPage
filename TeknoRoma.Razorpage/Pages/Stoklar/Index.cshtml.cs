using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class IndexModel(IManager<Stok> stokManager) : PageModel
    {
        public ICollection<Stok> Stoklar { get; set; }

        public async Task OnGet()
        {
            Stoklar = await stokManager.GetAllAsync(default);
        }
    }
}
