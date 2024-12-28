using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Faturalar
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Fatura> _manager;

        public DeleteModel(IManager<Fatura> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Fatura Fatura { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Fatura = await _manager.GetByIdAsync(id, default);
            if (Fatura == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Fatura != null)
            {
                var result = await _manager.DeleteAsync(Fatura, default); // Burada Birim nesnesini geçiriyoruz
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
