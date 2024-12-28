using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kasalar
{
    public class CreateModel(IManager<Kasa> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Kasa kasa = new();
            kasa.KasaKodu = InsertModel.KasaKodu;
            kasa.SubeKodu = InsertModel.SubeKodu;
            kasa.DovizId = InsertModel.DovizId;
            kasa.Bakiye = InsertModel.Bakiye;
            var result = await manager.InsertAsync(kasa, default);
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
            [Required(ErrorMessage = "KasaKodu zorunludur")]
            [DisplayName("KasaKodu")]
            public string? KasaKodu { get; set; }
            [Required(ErrorMessage = "SubeKodu zorunludur")]
            [DisplayName("SubeKodu")]
            public string? SubeKodu { get; set; }
            [Required(ErrorMessage = "DovizId zorunludur")]
            [DisplayName("DovizId")]
            public string DovizId { get; set; }
            [Required(ErrorMessage = "Bakiye zorunludur")]
            [DisplayName("Bakiye")]
            public double? Bakiye { get; set; }
        }
    }
}
