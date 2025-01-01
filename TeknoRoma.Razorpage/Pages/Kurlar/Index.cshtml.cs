using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kurlar
{
    public class IndexModel(IManager<Kur> kurManager) : PageModel
    {
        public ICollection<Kur> Kurlar { get; set; }

        public async Task OnGet()
        {
            Kurlar = await kurManager.GetAllAsync(default);
        }
    }
}
