using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kasalar
{
    public class IndexModel(IManager<Kasa> kasaManager) : PageModel
    {
        public ICollection<Kasa> Kasalar { get; set; }

        public async Task OnGet()
        {
            Kasalar = await kasaManager.GetAllAsync(default);
        }
    }
}
