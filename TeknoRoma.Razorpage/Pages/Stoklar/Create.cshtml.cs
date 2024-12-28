using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class CreateModel(IManager<Stok> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Stok stok = new();
            stok.StokAdi = InsertModel.StokAdi;
            stok.StokKodu = InsertModel.StokKodu;
            stok.DepoId = InsertModel.DepoId;
            stok.StokAdet = InsertModel.StokAdet;

            stok.Fiyat = InsertModel.Fiyat;
            stok.KategoriId = InsertModel.KategoriId;

            var result = await manager.InsertAsync(stok, default);
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
            [Required(ErrorMessage = "Stok Adi zorunludur")]
            [DisplayName("Stok Adi")]
            public string StokAdi { get; set; }
            [Required(ErrorMessage = "Stok Kodu zorunludur")]
            [DisplayName("Stok Kodu")]
            public string StokKodu { get; set; }
            [Required(ErrorMessage = "DepoId zorunludur")]
            [DisplayName("DepoId")]
            public string DepoId { get; set; }
            [Required(ErrorMessage = "Stok Adeti zorunludur")]
            [DisplayName("StokAdet")]
            public int StokAdet { get; set; }
            [Required(ErrorMessage = "BirimId zorunludur")]
            [DisplayName("BirimId")]
            public string BirimId { get; set; }
            [Required(ErrorMessage = "Fiyat zorunludur")]
            [DisplayName("Fiyat Kodu")]
            public double Fiyat { get; set; }
            [Required(ErrorMessage = "KategoriId zorunludur")]
            [DisplayName("KategoriId")]
            public string KategoriId { get; set; }
        }
    }
}