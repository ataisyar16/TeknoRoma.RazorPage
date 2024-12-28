using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Faturalar
{
    public class CreateModel(IManager<Fatura> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Fatura fatura = new();
            fatura.CariId = InsertModel.CariId;
            fatura.FaturaTarihi = InsertModel.FaturaTarihi;
            fatura.ToplamTutar = InsertModel.ToplamTutar;
            fatura.KDV = InsertModel.KDV;
            var result = await manager.InsertAsync(fatura, default);
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
            [Required(ErrorMessage = "Cari Id zorunludur")]
            [DisplayName("CariId")]
            public string CariId { get; set; }
            [Required(ErrorMessage = "Fatura Tarihi zorunludur")]
            [DisplayName("Fatura Tarihi")]
            public DateTime FaturaTarihi { get; set; }
            [Required(ErrorMessage = "Toplam Tutar zorunludur")]
            [DisplayName("Toplam Tutar")]
            public decimal ToplamTutar { get; set; }
            [Required(ErrorMessage = "KDV zorunludur")]
            [DisplayName("KDV")]
            public decimal KDV { get; set; }
        }
    }
}
