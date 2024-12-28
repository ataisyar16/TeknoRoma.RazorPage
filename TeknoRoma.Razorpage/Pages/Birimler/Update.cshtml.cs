using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Birimler
{
    public class UpdateModel : PageModel
    {
        private readonly IManager<Birim> _manager;

        public UpdateModel(IManager<Birim> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public InputModel EditModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id) // id'yi int olarak deðiþtirin
        {
            var birim = await _manager.GetByIdAsync(id, default);
            if (birim == null)
            {
                return NotFound();
            }

            EditModel.BirimKodu = birim.BirimKodu;
            EditModel.Aciklama = birim.Aciklama;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id) // id'yi int olarak deðiþtirin
        {
            if (ModelState.IsValid)
            {
                var birim = new Birim
                {
                    Id = id, // Burada id'yi doðrudan atýyoruz
                    BirimKodu = EditModel.BirimKodu,
                    Aciklama = EditModel.Aciklama
                };

                var result = await _manager.UpdateAsync(birim, default);
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
            [Required(ErrorMessage = "Birim kodu zorunludur")]
            [DisplayName("Birim Kodu")]
            public string? BirimKodu { get; set; }

            [Required(ErrorMessage = "Açýklama zorunludur")]
            [DisplayName("Açýklama")]
            public string? Aciklama { get; set; }
        }
    }
}