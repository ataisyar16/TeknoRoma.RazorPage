using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.SatisDetaylari
{
    public class DeleteModel(IManager<SatisDetay> satisDetayManager) : PageModel
    {


        [BindProperty]
        public SatisDetay SatisDetay { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            SatisDetay = await satisDetayManager.GetByIdAsync(id, default);
            if (SatisDetay == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SatisDetay != null)
            {
                var result = await satisDetayManager.DeleteAsync(SatisDetay, default); // Burada Birim nesnesini geçiriyoruz
                if (result.Success)
                {
                    return RedirectToPage("Index");
                }

                // Hata durumunda model state'e hata ekleyebilirsiniz
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code ?? "UnknownError", error.Message ?? "An unknown error occurred.");
                }
            }

            return Page();
        }
    }
}
