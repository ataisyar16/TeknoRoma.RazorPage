using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Cariler
{
    public class IndexModel(IManager<Cari> manager) : PageModel
    {

        public ICollection<Cari> Cariler { get; set; }
        public async Task OnGet()
        {
            Cariler = await manager.GetAllAsync(default);
        }

    }
}
