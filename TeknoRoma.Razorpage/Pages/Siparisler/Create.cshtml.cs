using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Siparisler
{
    public class CreateModel(IManager<Siparis> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Siparis siparis = new();
            siparis.CariId = InsertModel.CariId;
            siparis.SiparisTarihi = InsertModel.SiparisTarihi;
            siparis.Durum = InsertModel.Durum;
            var result = await manager.InsertAsync(siparis, default);
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
            [Required(ErrorMessage = "CariId zorunludur")]
            [DisplayName("CariId")]
            public string CariId { get; set; }
            [Required(ErrorMessage = "SiparisTarihi zorunludur")]
            [DisplayName("SiparisTarihi")]
            public DateTime? SiparisTarihi { get; set; }
            [Required(ErrorMessage = "Durum zorunludur")]
            [DisplayName("Durum")]
            public string? Durum { get; set; }
        }
    }
}
