using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.SiparisDetaylari
{
    public class CreateModel(IManager<SiparisDetay> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SiparisDetay siparisDetay = new();
            siparisDetay.SiparisId = InsertModel.SiparisId;
            siparisDetay.StokId = InsertModel.StokId;
            siparisDetay.Miktar = InsertModel.Miktar;
            siparisDetay.BirimFiyat = InsertModel.BirimFiyat;
            var result = await manager.InsertAsync(siparisDetay, default);
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
            [Required(ErrorMessage = "SiparisId zorunludur")]
            [DisplayName("SiparisId")]
            public string SiparisId { get; set; }
            [Required(ErrorMessage = "StokId zorunludur")]
            [DisplayName("StokId")]
            public string StokId { get; set; }
            [Required(ErrorMessage = "Miktar zorunludur")]
            [DisplayName("Miktar")]
            public int Miktar { get; set; }
            [Required(ErrorMessage = "BirimFiyat zorunludur")]
            [DisplayName("BirimFiyat")]
            public double BirimFiyat { get; set; }
            [Required(ErrorMessage = "Aciklama zorunludur")]
            [DisplayName("Aciklama")]
            public string? Aciklama { get; set; }
        }
    }
}
