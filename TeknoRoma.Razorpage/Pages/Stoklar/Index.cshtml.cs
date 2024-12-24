using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class IndexModel(IManager<Stok> manager) : PageModel
    {
        public ICollection<Stok> Stoklar { get; set; } = new List<Stok>();

        public async Task OnGetAsync()
        {
            Stoklar = await manager.GetAllAsync(default);
        }
    }
}
