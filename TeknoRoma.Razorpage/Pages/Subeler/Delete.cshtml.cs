using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Subeler
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Sube> _manager;

        public DeleteModel(IManager<Sube> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Sube Sube { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Sube = await _manager.GetByIdAsync(id, default);
            if (Sube == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Sube != null)
            {
                var result = await _manager.DeleteAsync(Sube, default); // Burada Birim nesnesini geçiriyoruz
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
