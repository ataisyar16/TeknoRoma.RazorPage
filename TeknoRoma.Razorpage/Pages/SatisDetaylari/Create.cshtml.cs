using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.SatisDetaylari
{
    public class CreateModel(IManager<SatisDetay> satisDetayManager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SatisDetay satisDetay = new();
            satisDetay.SatisId = InsertModel.SatisId;
            satisDetay.StokId = InsertModel.StokId;
            satisDetay.Miktar = InsertModel.Miktar;
            satisDetay.BirimFiyat = InsertModel.BirimFiyat;
            var result = await satisDetayManager.InsertAsync(satisDetay, default);
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
            [Required(ErrorMessage = "SatisId zorunludur")]
            [DisplayName("SatisId")]
            public string SatisId { get; set; }
            [Required(ErrorMessage = "StokId zorunludur")]
            [DisplayName("StokId")]
            public string StokId { get; set; }
            [Required(ErrorMessage = "Miktar zorunludur")]
            [DisplayName("Miktar")]
            public int? Miktar { get; set; }
            [Required(ErrorMessage = "BirimFiyat zorunludur")]
            [DisplayName("BirimFiyat")]
            public double BirimFiyat { get; set; }
        }
    }
}
