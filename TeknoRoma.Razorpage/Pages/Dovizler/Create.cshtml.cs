using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Dovizler
{
    public class CreateModel(IManager<Doviz> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Doviz doviz = new();
            doviz.DovizKodu = InsertModel.DovizKodu;
            doviz.DovizAdi = InsertModel.DovizAdi;
            doviz.Kur = InsertModel.Kur;
            var result = await manager.InsertAsync(doviz, default);
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
            [Required(ErrorMessage = "Doviz Kodu zorunludur")]
            [DisplayName("Doviz Kodu")]
            public string DovizKodu { get; set; }

            [Required(ErrorMessage = "Doviz Adi zorunludur")]
            [DisplayName("Doviz Adi")]
            public string DovizAdi { get; set; }

            [Required(ErrorMessage = "Kur zorunludur")]
            [DisplayName("Kur")]
            public decimal Kur { get; set; }
        }
    }
}
