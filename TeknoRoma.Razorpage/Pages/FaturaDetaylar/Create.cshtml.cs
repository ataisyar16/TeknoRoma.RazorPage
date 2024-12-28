using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.FaturaDetaylar
{
    public class CreateModel(IManager<FaturaDetay> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FaturaDetay FaturaDetay = new();
            FaturaDetay.FaturaId = InsertModel.FaturaId;
            FaturaDetay.StokId = InsertModel.StokId;
            FaturaDetay.Miktar = InsertModel.Miktar;
            FaturaDetay.Fiyat = InsertModel.Fiyat;
            var result = await manager.InsertAsync(FaturaDetay, default);
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
            [Required(ErrorMessage = "FaturaId zorunludur")]
            [DisplayName("FaturaId")]
            public string FaturaId { get; set; }
            [Required(ErrorMessage = "StokId zorunludur")]
            [DisplayName("StokId")]
            public string StokId { get; set; }
            [Required(ErrorMessage = "Miktar zorunludur")]
            [DisplayName("Miktar")]
            public int? Miktar { get; set; }
            [Required(ErrorMessage = "Fiyat zorunludur")]
            [DisplayName("Fiyat")]
            public double? Fiyat { get; set; }

        }
    }
}
