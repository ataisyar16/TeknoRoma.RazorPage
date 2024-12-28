using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.KasaHareketler
{
    public class CreateModel(IManager<KasaHareket> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            KasaHareket kasaHareket = new();
            kasaHareket.KasaId = InsertModel.KasaId;
            kasaHareket.DovizId = InsertModel.DovizId;
            kasaHareket.HareketTipi = InsertModel.HareketTipi;
            kasaHareket.Giris = InsertModel.Giris;
            kasaHareket.Cikis = InsertModel.Cikis;
            kasaHareket.Tutar = InsertModel.Tutar;
            kasaHareket.Tarih = InsertModel.Tarih;
            var result = await manager.InsertAsync(kasaHareket, default);
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
            [Required(ErrorMessage = "KasaId zorunludur")]
            [DisplayName("KasaId")]
            public string KasaId { get; set; }
            [Required(ErrorMessage = "DovizId zorunludur")]
            [DisplayName("DovizId")]
            public string DovizId { get; set; }
            [Required(ErrorMessage = "Hareket Tipi zorunludur")]
            [DisplayName("Hareket Tipi")]
            public string? HareketTipi { get; set; }
            [Required(ErrorMessage = "Kasa Giris zorunludur")]
            [DisplayName("Kasa Giris")]
            public decimal? Giris { get; set; }
            [Required(ErrorMessage = "Kasa Cikis zorunludur")]
            [DisplayName("Cikis")]
            public decimal? Cikis { get; set; }
            [Required(ErrorMessage = "Tutar zorunludur")]
            [DisplayName("Tutar")]
            public decimal? Tutar { get; set; }
            [Required(ErrorMessage = "Tarih zorunludur")]
            [DisplayName("Tarih")]
            public DateTime? Tarih { get; set; }
        }
    }
}
