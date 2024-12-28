using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Birimler
{
    public class CreateModel(IManager<Birim> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Birim birim = new();
            birim.BirimKodu = InsertModel.BirimKodu;
            birim.Aciklama = InsertModel.Aciklama;
            var result = await manager.InsertAsync(birim, default);
            if (result.Success)
            {
                return RedirectToPage("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Message);
                }
                return Page();
            }
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Birim kodu zorunludur")]
            [DisplayName("Birim Kodu")]
            public string? BirimKodu { get; set; }

            [Required(ErrorMessage = "Aciklama zorunludur")]
            [DisplayName("Aciklama")]
            public string? Aciklama { get; set; }
        }
    }
}
