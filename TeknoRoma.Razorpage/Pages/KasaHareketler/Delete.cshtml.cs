using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.KasaHareketler
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<KasaHareket> _manager;

        public DeleteModel(IManager<KasaHareket> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public KasaHareket KasaHareket { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            KasaHareket = await _manager.GetByIdAsync(id, default);
            if (KasaHareket == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (KasaHareket != null)
            {
                var result = await _manager.DeleteAsync(KasaHareket, default); // Burada KasaHareket nesnesini geçiriyorum
                if (result.Success)
                {
                    return RedirectToPage("Index");
                }

                // Hata durumunda model state'e hata ekleyebilirim
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code ?? "UnknownError", error.Message ?? "An unknown error occurred.");
                }
            }

            return Page();
        }
    }
}
