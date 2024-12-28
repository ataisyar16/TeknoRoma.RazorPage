using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Subeler
{
    public class CreateModel(IManager<Sube> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Sube sube = new();
            sube.SubeAdi = InsertModel.SubeAdi;
            sube.Sehir = InsertModel.Sehir;
            sube.Ilce = InsertModel.Ilce;
            sube.Address = InsertModel.Address;
            var result = await manager.InsertAsync(sube, default);
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
            [Required(ErrorMessage = "Sube Adi zorunludur")]
            [DisplayName("Sube Adi")]
            public string? SubeAdi { get; set; }
            [Required(ErrorMessage = "Sehir zorunludur")]
            [DisplayName("Sehir")]
            public string? Sehir { get; set; }
            [Required(ErrorMessage = "Ilce zorunludur")]
            [DisplayName("Ilce")]
            public string? Ilce { get; set; }
            [Required(ErrorMessage = "Address zorunludur")]
            [DisplayName("Address")]
            public string? Address { get; set; }
        }
    }
}
