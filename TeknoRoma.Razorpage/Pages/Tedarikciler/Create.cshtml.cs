using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Tedarikciler
{
    public class CreateModel(IManager<Tedarikci> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Tedarikci tedarikci = new();
            tedarikci.Ad = InsertModel.Ad;
            tedarikci.Telefon = InsertModel.Telefon;
            tedarikci.Email = InsertModel.Email;
            tedarikci.Adres = InsertModel.Adres;
            var result = await manager.InsertAsync(tedarikci, default);
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
            [Required(ErrorMessage = "Ad zorunludur")]
            [DisplayName("Ad")]
            public string? Ad { get; set; }
            [Required(ErrorMessage = " Telefon zorunludur")]
            [DisplayName("Telefon")]
            public string? Telefon { get; set; }
            [Required(ErrorMessage = "Email zorunludur")]
            [DisplayName("Email")]
            public string? Email { get; set; }
            [Required(ErrorMessage = "Adres zorunludur")]
            [DisplayName("Adres")]
            public string? Adres { get; set; }
        }
    }
}
