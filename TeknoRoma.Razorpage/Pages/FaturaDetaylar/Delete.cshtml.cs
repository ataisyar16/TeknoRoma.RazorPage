using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.FaturaDetaylar
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<FaturaDetay> _manager;

        public DeleteModel(IManager<FaturaDetay> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public FaturaDetay FaturaDetay { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            FaturaDetay = await _manager.GetByIdAsync(id, default);
            if (FaturaDetay == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (FaturaDetay != null)
            {
                var result = await _manager.DeleteAsync(FaturaDetay, default); // Burada Birim nesnesini geçiriyoruz
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
