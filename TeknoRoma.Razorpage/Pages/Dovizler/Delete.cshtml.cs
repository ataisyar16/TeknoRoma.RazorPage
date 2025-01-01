using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Dovizler
{
    public class DeleteModel(IManager<Doviz> dovizManager) : PageModel
    {
        [BindProperty]
        public Doviz Doviz { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Doviz = await dovizManager.GetByIdAsync(id, default);
            if (Doviz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Doviz != null)
            {
                var result = await dovizManager.DeleteAsync(Doviz, default); // Burada Birim nesnesini geçiriyoruz
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
