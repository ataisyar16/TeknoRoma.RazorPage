using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Birimler
{
    public class IndexModel(IManager<Birim> birimManager) : PageModel
    {
        public ICollection<Birim> Birimler { get; set; }

        public async Task OnGet()
        {
            Birimler = await birimManager.GetAllAsync(default);
        }
    }
}