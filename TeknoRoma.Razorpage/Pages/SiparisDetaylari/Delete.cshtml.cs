using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.SiparisDetaylari
{
    public class DeleteModel : PageModel
    {
        private readonly IManager<SiparisDetay> _manager;

        public DeleteModel(IManager<SiparisDetay> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public SiparisDetay SiparisDetay { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            SiparisDetay = await _manager.GetByIdAsync(id, default);
            if (SiparisDetay == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SiparisDetay != null)
            {
                var result = await _manager.DeleteAsync(SiparisDetay, default); // Burada Birim nesnesini geçiriyoruz
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
