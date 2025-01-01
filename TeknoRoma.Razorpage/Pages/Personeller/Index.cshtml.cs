using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Personeller
{
    public class IndexModel(IManager<Personel> personelManager) : PageModel
    {
        public ICollection<Personel> Personeller { get; set; }

        public async Task OnGet()
        {
            Personeller = await personelManager.GetAllAsync(default);
        }
    }
}
