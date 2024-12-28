using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.KullaniciYorumlari
{
    public class IndexModel(IManager<KullaniciYorum> kullaniciYorumManager) : PageModel
    {
        public ICollection<KullaniciYorum> KullaniciYorumlari { get; set; }

        public async Task OnGet()
        {
            KullaniciYorumlari = await kullaniciYorumManager.GetAllAsync(default);
        }
    }
}
