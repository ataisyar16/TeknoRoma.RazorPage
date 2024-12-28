using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Subeler
{
    public class IndexModel(IManager<Sube> subeManager) : PageModel
    {
        public ICollection<Sube> Subeler { get; set; }

        public async Task OnGet()
        {
            Subeler = await subeManager.GetAllAsync(default);
        }
    }
}
