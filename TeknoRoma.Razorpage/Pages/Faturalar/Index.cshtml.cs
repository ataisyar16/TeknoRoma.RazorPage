using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Faturalar
{
    public class IndexModel(IManager<Fatura> faturaManager) : PageModel
    {
        public ICollection<Fatura> Faturalar { get; set; }

        public async Task OnGet()
        {
            Faturalar = await faturaManager.GetAllAsync(default);
        }
    }
}
