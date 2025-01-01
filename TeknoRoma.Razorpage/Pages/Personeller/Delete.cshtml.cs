using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Personeller
{
    public class DeleteModel(IManager<Personel> personelManager) : PageModel
    {


        [BindProperty]
        public Personel Personel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Personel = await personelManager.GetByIdAsync(id, default);
            if (Personel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Personel != null)
            {
                var result = await personelManager.DeleteAsync(Personel, default); // Burada Birim nesnesini geçiriyoruz
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
