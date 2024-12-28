using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Departmanlar
{
    public class CreateModel(IManager<Departman> manager) : PageModel
    {
        [BindProperty]
        public InputModel InsertModel { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Departman departman = new();
            departman.DepartmanAdi = InsertModel.DepartmanAdi;
            departman.UstId = InsertModel.UstId;
            var result = await manager.InsertAsync(departman, default);
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
            [Required(ErrorMessage = "DepartmanAdi zorunludur")]
            [DisplayName("DepartmanAdi")]
            public string DepartmanAdi { get; set; }
            [Required(ErrorMessage = "UstId zorunludur")]
            [DisplayName("UstId")]
            public string UstId { get; set; } // Parent Departman ID
        }
    }
}
