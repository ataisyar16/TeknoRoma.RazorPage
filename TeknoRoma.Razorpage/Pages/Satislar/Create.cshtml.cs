using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Satislar
{
    public class CreateModel(IManager<Satis> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var satis = new Satis
                {
                    CariId = InsertModel.CariId,
                    PersonelId = InsertModel.PersonelId,
                    SubeId = InsertModel.SubeId,
                    SatisTarihi = InsertModel.SatisTarihi,
                    ToplamTutar = InsertModel.ToplamTutar
                };

                var result = await manager.InsertAsync(satis, default);
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
            public string CariId { get; set; }

            [Required]
            public string PersonelId { get; set; }

            [Required]
            public string SubeId { get; set; }

            public DateTime? SatisTarihi { get; set; }

            [Required]
            public double ToplamTutar { get; set; }
        }
    }
}
