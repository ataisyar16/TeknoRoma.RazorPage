using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.KullaniciYorumlari
{
    public class CreateModel(IManager<KullaniciYorum> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            KullaniciYorum KullaniciYorum = new();
            KullaniciYorum.KullaniciId = InsertModel.KullaniciId;
            KullaniciYorum.StokId = InsertModel.StokId;
            KullaniciYorum.YorumMetni = InsertModel.YorumMetni;
            KullaniciYorum.YorumTarihi = InsertModel.YorumTarihi;
            var result = await manager.InsertAsync(KullaniciYorum, default);
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
            [Required(ErrorMessage = "KullaniciId zorunludur")]
            [DisplayName("KullaniciId")]
            public string KullaniciId { get; set; }
            [Required(ErrorMessage = "StokId zorunludur")]
            [DisplayName("StokId")]
            public string StokId { get; set; }
            [Required(ErrorMessage = "YorumMetni zorunludur")]
            [DisplayName("YorumMetni")]
            public string? YorumMetni { get; set; }
            [Required(ErrorMessage = "YorumTarihi zorunludur")]
            [DisplayName("YorumTarihi")]
            public DateTime YorumTarihi { get; set; }
        }
    }
}
