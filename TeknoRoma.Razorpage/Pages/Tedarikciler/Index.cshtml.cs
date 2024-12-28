using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Tedarikciler
{
    public class IndexModel(IManager<Tedarikci> tedarikciManager) : PageModel
    {
        public ICollection<Tedarikci> Tedarikciler { get; set; }

        public async Task OnGet()
        {
            Tedarikciler = await tedarikciManager.GetAllAsync(default);
        }
    }
}
