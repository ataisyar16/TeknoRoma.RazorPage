using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Kurlar
{
    public class CreateModel(IManager<Kur> kurManager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Kur kur = new();
            kur.DovizId = InsertModel.DovizId;
            kur.KurTarihi = InsertModel.KurTarihi;
            kur.AlisKuru = InsertModel.AlisKuru;
            kur.SatisKuru = InsertModel.SatisKuru;
            var result = await kurManager.InsertAsync(kur, default);
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
            [Required(ErrorMessage = "Doviz Id zorunludur")]
            [DisplayName("DovizId")]
            public string DovizId { get; set; }
            [Required(ErrorMessage = "Kur Tarihi zorunludur")]
            [DisplayName("KurTarihi")]
            public DateTime? KurTarihi { get; set; }
            [Required(ErrorMessage = "Alis Kuru zorunludur")]
            [DisplayName("AlisKuru")]
            public double? AlisKuru { get; set; }
            [Required(ErrorMessage = "Satis Kuru zorunludur")]
            [DisplayName("Satis Kuru")]
            public double? SatisKuru { get; set; }
        }
    }
}
