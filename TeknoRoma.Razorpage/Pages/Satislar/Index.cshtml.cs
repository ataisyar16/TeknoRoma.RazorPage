using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Satislar
{
    public class IndexModel(IManager<Satis> manager) : PageModel
    {
        public ICollection<Satis> Satislar { get; set; } = new List<Satis>();

        public async Task OnGetAsync()
        {
            Satislar = await manager.GetAllAsync(default);
        }
    }
}
