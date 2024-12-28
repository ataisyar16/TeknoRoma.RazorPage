using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Birimler
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<Birim> _manager;

        public DeleteModel(IManager<Birim> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public Birim Birim { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Birim = await _manager.GetByIdAsync(id, default);
            if (Birim == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Birim != null)
            {
                var result = await _manager.DeleteAsync(Birim, default); // Burada Birim nesnesini geçiriyoruz
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