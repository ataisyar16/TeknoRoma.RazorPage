using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kurlar
{
    public class DeleteModel(IManager<Kur> kurManager) : PageModel
    {


        [BindProperty]
        public Kur Kur { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Kur = await kurManager.GetByIdAsync(id, default);
            if (Kur == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Kur != null)
            {
                var result = await kurManager.DeleteAsync(Kur, default); // Burada Birim nesnesini geçiriyoruz
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
