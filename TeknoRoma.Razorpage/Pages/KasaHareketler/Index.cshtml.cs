using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.KasaHareketler
{
    public class IndexModel(IManager<KasaHareket> kasaHareketManager) : PageModel
    {
        public ICollection<KasaHareket> KasaHareketler { get; set; }

        public async Task OnGet()
        {
            KasaHareketler = await kasaHareketManager.GetAllAsync(default);
        }
    }
}
