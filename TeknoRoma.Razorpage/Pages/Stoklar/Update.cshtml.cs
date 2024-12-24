using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class UpdateStokModel(IManager<Stok> manager) : PageModel
    {
        [BindProperty]
        public InputModel UpdateModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Stok bilgilerini al
            var stok = await manager.GetByIdAsync(id, default);
            if (stok == null)
            {
                return NotFound();
            }

            // InputModel'e bilgileri bind et
            UpdateModel = new InputModel
            {
                Id = stok.Id,
                StokAdi = stok.StokAdi,
                StokKodu = stok.StokKodu,
                DepoId = stok.DepoId,
                BirimId = stok.BirimId,
                Fiyat = stok.Fiyat,
                StokAdet = stok.StokAdet,
                KategoriId = stok.KategoriId
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Güncelleme için Stok nesnesini oluþtur
                var stok = new Stok
                {
                    Id = UpdateModel.Id,
                    StokAdi = UpdateModel.StokAdi,
                    StokKodu = UpdateModel.StokKodu,
                    DepoId = UpdateModel.DepoId,
                    BirimId = UpdateModel.BirimId,
                    Fiyat = UpdateModel.Fiyat,
                    StokAdet = UpdateModel.StokAdet,
                    KategoriId = UpdateModel.KategoriId
                };

                // Güncelleme iþlemi
                var result = await manager.UpdateAsync(stok, default);
                if (result.Success)
                {
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Message);
                }
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            public string Id { get; set; }

            [Required]
            public string? StokAdi { get; set; }

            [Required]
            public string? StokKodu { get; set; }

            [Required]
            public string DepoId { get; set; }

            [Required]
            public string BirimId { get; set; }

            public double? Fiyat { get; set; }

            public int? StokAdet { get; set; }

            public string KategoriId { get; set; }
        }
    }
}
