using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.SiparisDetaylari
{
    public class IndexModel(IManager<SiparisDetay> siparisDetayManager) : PageModel
    {
        public ICollection<SiparisDetay> SiparisDetaylar { get; set; }

        public async Task OnGet()
        {
            SiparisDetaylar = await siparisDetayManager.GetAllAsync(default);
        }
    }
}
