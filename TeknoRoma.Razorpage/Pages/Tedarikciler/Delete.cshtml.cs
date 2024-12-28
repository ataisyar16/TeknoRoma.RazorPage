using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Tedarikciler
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Tedarikci> _manager;

        public DeleteModel(IManager<Tedarikci> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Tedarikci Tedarikci { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Tedarikci = await _manager.GetByIdAsync(id, default);
            if (Tedarikci == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Tedarikci != null)
            {
                var result = await _manager.DeleteAsync(Tedarikci, default); // Burada Birim nesnesini geçiriyoruz
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
