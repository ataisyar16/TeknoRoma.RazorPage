using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.FaturaDetaylar
{
    public class IndexModel(IManager<FaturaDetay> FaturaDetayManager) : PageModel
    {
        public ICollection<FaturaDetay> FaturaDetaylar { get; set; }

        public async Task OnGet()
        {
            FaturaDetaylar = await FaturaDetayManager.GetAllAsync(default);
        }
    }
}
