using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Dovizler
{
    public class IndexModel(IManager<Doviz> dovizManager) : PageModel
    {
        public ICollection<Doviz> Dovizler { get; set; }

        public async Task OnGet()
        {
            Dovizler = await dovizManager.GetAllAsync(default);
        }
    }
}
