using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Cariler
{
    public class CreateModel(IManager<Cari> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var cari = new Cari
                {
                    SubeNo = InsertModel.SubeNo,
                    CariHesapNo = InsertModel.CariHesapNo,
                    Sehir = InsertModel.Sehir,
                    Ilce = InsertModel.Ilce,
                    Adres = InsertModel.Adres,
                    Bakiye = (decimal)InsertModel.Bakiye
                };

                var result = await manager.InsertAsync(cari, default);
                if (result.Success)
                {
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Message);
                }
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            public string? SubeNo { get; set; }

            [Required]
            public string? CariHesapNo { get; set; }

            [Required]
            public string Sehir { get; set; }

            [Required]
            public string Ilce { get; set; }

            public string? Adres { get; set; }

            public decimal? Bakiye { get; set; }
        }
    }
}
