using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Siparisler
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Siparis> _manager;

        public DeleteModel(IManager<Siparis> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Siparis Siparis { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Siparis = await _manager.GetByIdAsync(id, default);
            if (Siparis == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Siparis != null)
            {
                var result = await _manager.DeleteAsync(Siparis, default); // Burada Birim nesnesini geçiriyoruz
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
