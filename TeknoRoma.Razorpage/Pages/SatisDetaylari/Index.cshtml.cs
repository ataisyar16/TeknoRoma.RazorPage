using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.SatisDetaylari
{
    public class IndexModel(IManager<SatisDetay> satisDetayManager) : PageModel
    {
        public ICollection<SatisDetay> SatisDetaylar { get; set; }

        public async Task OnGet()
        {
            SatisDetaylar = await satisDetayManager.GetAllAsync(default);
        }
    }
}
