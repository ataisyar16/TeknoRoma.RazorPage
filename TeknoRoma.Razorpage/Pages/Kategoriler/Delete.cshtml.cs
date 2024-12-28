using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kategoriler
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Kategori> _manager;

        public DeleteModel(IManager<Kategori> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Kategori Kategori { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Kategori = await _manager.GetByIdAsync(id, default);
            if (Kategori == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Kategori != null)
            {
                var result = await _manager.DeleteAsync(Kategori, default); // Burada Birim nesnesini geçiriyoruz
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
