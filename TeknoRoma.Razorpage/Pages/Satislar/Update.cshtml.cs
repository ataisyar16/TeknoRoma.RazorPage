using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Satislar
{
    public class UpdateModel(IManager<Satis> manager) : PageModel
    {
        [BindProperty]
        public InputModel EditModel { get; set; } = new();

        public async Task OnGetAsync(string id)
        {
            var satis = await manager.GetByIdAsync(id, default);
            if (satis != null)
            {
                EditModel = new InputModel
                {
                    Id = satis.Id,
                    CariId = satis.CariId,
                    PersonelId = satis.PersonelId,
                    SubeId = satis.SubeId,
                    SatisTarihi = satis.SatisTarihi,
                    ToplamTutar = satis.ToplamTutar
                };
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var satis = new Satis
                {
                    Id = EditModel.Id,
                    CariId = EditModel.CariId,
                    PersonelId = EditModel.PersonelId,
                    SubeId = EditModel.SubeId,
                    SatisTarihi = EditModel.SatisTarihi,
                    ToplamTutar = EditModel.ToplamTutar
                };

                var result = await manager.UpdateAsync(satis, default);
                if (result.Success)
                {
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            public string Id { get; set; }

            public string CariId { get; set; }

            public string PersonelId { get; set; }

            public string SubeId { get; set; }

            public DateTime? SatisTarihi { get; set; }

            public double ToplamTutar { get; set; }
        }
    }
}
