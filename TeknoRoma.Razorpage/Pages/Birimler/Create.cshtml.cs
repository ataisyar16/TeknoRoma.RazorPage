using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Birimler
{
    public class CreateModel(IManager<Birim> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var birim = new Birim
                {
                    BirimKodu = InsertModel.BirimKodu,
                    Aciklama = InsertModel.Aciklama
                };

                var result = await manager.InsertAsync(birim, default);
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
            [Required]
            public string? BirimKodu { get; set; }

            [Required]
            public string? Aciklama { get; set; }
        }
    }
}
