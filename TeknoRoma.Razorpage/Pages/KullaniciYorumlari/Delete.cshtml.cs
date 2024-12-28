using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.KullaniciYorumlari
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<KullaniciYorum> _manager;

        public DeleteModel(IManager<KullaniciYorum> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public KullaniciYorum KullaniciYorum { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            KullaniciYorum = await _manager.GetByIdAsync(id, default);
            if (KullaniciYorum == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (KullaniciYorum != null)
            {
                var result = await _manager.DeleteAsync(KullaniciYorum, default); // Burada Birim nesnesini geçiriyoruz
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
