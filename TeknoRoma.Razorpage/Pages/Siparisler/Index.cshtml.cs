using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Siparisler
{
    public class IndexModel(IManager<Siparis> siparisManager) : PageModel
    {
        public ICollection<Siparis> Siparisler { get; set; }

        public async Task OnGet()
        {
            Siparisler = await siparisManager.GetAllAsync(default);
        }
    }
}
