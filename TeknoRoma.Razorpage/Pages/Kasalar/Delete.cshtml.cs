using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kasalar
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Kasa> _manager;

        public DeleteModel(IManager<Kasa> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Kasa Kasa { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Kasa = await _manager.GetByIdAsync(id, default);
            if (Kasa == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Kasa != null)
            {
                var result = await _manager.DeleteAsync(Kasa, default); // Burada Birim nesnesini geçiriyoruz
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
