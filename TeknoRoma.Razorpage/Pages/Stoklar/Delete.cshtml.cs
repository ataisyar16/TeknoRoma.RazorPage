using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Stok> _manager;

        public DeleteModel(IManager<Stok> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Stok Stok { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Stok = await _manager.GetByIdAsync(id, default);
            if (Stok == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Stok != null)
            {
                var result = await _manager.DeleteAsync(Stok, default); // Burada Birim nesnesini geçiriyoruz
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
