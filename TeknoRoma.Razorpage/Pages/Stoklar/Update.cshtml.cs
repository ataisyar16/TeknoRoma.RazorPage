using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Stoklar
{
    public class UpdateModel : PageModel
    {
        private readonly IManager<Stok> _manager;

        public UpdateModel(IManager<Stok> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public InputModel EditModel { get; set; } = new();

        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var stok = await _manager.GetByIdAsync(id.ToString(), default);
            if (stok == null)
            {
                return NotFound($"Id '{id}' ile bir stok bulunamadý.");
            }

            Id = id;
            EditModel.Id = id.ToString();
            EditModel.StokAdi = stok.StokAdi;
            EditModel.StokKodu = stok.StokKodu;
            EditModel.DepoId = stok.DepoId;
            EditModel.StokAdet = stok.StokAdet;

            EditModel.Fiyat = stok.Fiyat;
            EditModel.KategoriId = stok.KategoriId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var stok = new Stok
                {
                    Id = EditModel.Id,
                    StokAdi = EditModel.StokAdi,
                    StokKodu = EditModel.StokKodu,
                    DepoId = EditModel.DepoId,
                    StokAdet = (int)EditModel.StokAdet,

                    Fiyat = (double)EditModel.Fiyat,
                    KategoriId = EditModel.KategoriId
                };

                var result = await _manager.UpdateAsync(stok, default);
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
            public string Id { get; set; }

            [Required(ErrorMessage = "Stok adý zorunludur")]
            [DisplayName("Stok Adý")]
            public string? StokAdi { get; set; }

            [Required(ErrorMessage = "Stok kodu zorunludur")]
            [DisplayName("Stok Kodu")]
            public string? StokKodu { get; set; }

            [Required(ErrorMessage = "Depo ID zorunludur")]
            [DisplayName("Depo ID")]
            public string DepoId { get; set; }

            [DisplayName("Stok Adet")]
            public int? StokAdet { get; set; }

            [Required(ErrorMessage = "Birim ID zorunludur")]
            [DisplayName("Birim ID")]
            public string BirimId { get; set; }

            [DisplayName("Fiyat")]
            public double? Fiyat { get; set; }

            [Required(ErrorMessage = "Kategori ID zorunludur")]
            [DisplayName("Kategori ID")]
            public string KategoriId { get; set; }
        }
    }
}


