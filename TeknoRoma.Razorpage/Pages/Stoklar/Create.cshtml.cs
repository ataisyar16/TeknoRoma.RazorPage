using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class CreateModel : PageModel
    {
        private readonly IManager<Stok> _manager;
        public CreateModel(IManager<Stok> manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        [BindProperty]
        public InputModel InsertModel { get; set; } = new();
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync �al��t�!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState ge�ersiz!");
                return Page();
            }

            try
            {
                var stok = new Stok
                {
                    StokAdi = InsertModel.StokAdi,
                    StokKodu = InsertModel.StokKodu,
                    DepoId = InsertModel.DepoId,
                    BirimId = InsertModel.BirimId,
                    Fiyat = InsertModel.Fiyat,
                    StokAdet = InsertModel.StokAdet,
                    KategoriId = InsertModel.KategoriId
                };

                var result = await _manager.InsertAsync(stok, default);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok ba�ar�yla eklendi!";
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                ModelState.AddModelError("", $"Bir hata olu�tu: {ex.Message}");
            }

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Stok Ad� alan� zorunludur.")]
            public string? StokAdi { get; set; }

            [Required(ErrorMessage = "Stok Kodu alan� zorunludur.")]
            public string? StokKodu { get; set; }

            [Required(ErrorMessage = "Depo ID alan� zorunludur.")]
            public string DepoId { get; set; }

            [Required(ErrorMessage = "Birim ID alan� zorunludur.")]
            public string BirimId { get; set; }

            [Range(0, double.MaxValue, ErrorMessage = "Fiyat de�eri negatif olamaz.")]
            public double? Fiyat { get; set; }

            [Range(0, int.MaxValue, ErrorMessage = "Stok Adet de�eri negatif olamaz.")]
            public int? StokAdet { get; set; }

            [Required(ErrorMessage = "Kategori ID alan� zorunludur.")]
            public string KategoriId { get; set; }
        }
    }
}
