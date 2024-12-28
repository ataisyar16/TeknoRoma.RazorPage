using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Depolar
{
    public class CreateModel(IManager<Depo> depoManager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Depo depo = new()
                {
                    DepoAdi = InsertModel.DepoAdi,
                    SubeId = InsertModel.SubeId,
                    Adres = InsertModel.Adres
                };

                var result = await depoManager.InsertAsync(depo, default);
                if (result.Success)
                {
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Message);
                }
            }

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "DepoAdi zorunludur")]
            [DisplayName("DepoAdi Kodu")]
            public string? DepoAdi { get; set; }

            [Required(ErrorMessage = "SubeId zorunludur")]
            [DisplayName("SubeId")]
            public string SubeId { get; set; }
            [Required(ErrorMessage = "Adres zorunludur")]
            [DisplayName("Adres")]
            public string Adres { get; set; }
        }
    }
}
