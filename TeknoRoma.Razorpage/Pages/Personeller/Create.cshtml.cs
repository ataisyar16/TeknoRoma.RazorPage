using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Personeller
{
    public class CreateModel(IManager<Personel> personelManager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Personel personel = new();
            personel.SubeId = InsertModel.SubeId;
            personel.Ad = InsertModel.Ad;
            personel.Soyad = InsertModel.Soyad;
            personel.TcNo = InsertModel.TcNo;
            personel.DepartmanId = InsertModel.DepartmanId;
            personel.Cinsiyet = InsertModel.Cinsiyet;
            personel.Gorev = InsertModel.Gorev;
            var result = await personelManager.InsertAsync(personel, default);
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
            [Required(ErrorMessage = "SubeId zorunludur")]
            [DisplayName("SubeId")]
            public string SubeId { get; set; }
            [Required(ErrorMessage = "Ad zorunludur")]
            [DisplayName("Ad")]
            public string? Ad { get; set; }
            [Required(ErrorMessage = "Soyad zorunludur")]
            [DisplayName("Soyad")]
            public string? Soyad { get; set; }
            [Required(ErrorMessage = "TcNo zorunludur")]
            [DisplayName("TcNo")]
            public string? TcNo { get; set; }
            [Required(ErrorMessage = "DepartmanId zorunludur")]
            [DisplayName("DepartmanId")]
            public string DepartmanId { get; set; }
            [Required(ErrorMessage = "Cinsiyet zorunludur")]
            [DisplayName("Cinsiyet")]
            public bool? Cinsiyet { get; set; }
            [Required(ErrorMessage = "Gorev zorunludur")]
            [DisplayName("Gorev")]
            public string? Gorev { get; set; }
        }
    }
}
