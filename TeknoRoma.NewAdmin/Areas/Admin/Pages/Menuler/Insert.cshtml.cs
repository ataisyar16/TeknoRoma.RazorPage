using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Menuler
{
    public class InsertModel(IManager<Menu> menuManager) : PageModel
    {


        [BindProperty]
        public MenuVM MenuInsertVM { get; set; } = new();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Menu menu = new();
            menu.MenuAdi = MenuInsertVM.MenuAdi;
            menu.Page = MenuInsertVM.Page;
            menu.Icon = MenuInsertVM.Icon;
            menu.Css = MenuInsertVM.Css;
            menu.Area = MenuInsertVM.Area;
            menu.Title = MenuInsertVM.Title;
            menu.Description = MenuInsertVM.Description;
            var result = await menuManager.InsertAsync(menu, default);
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

        public class MenuVM
        {

            [Required(ErrorMessage = "Menu Adi Zoruludur")]
            public string MenuAdi { get; set; }
            public string? Page { get; set; }
            public string? Icon { get; set; }
            public string? Css { get; set; }
            public string? Area { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }

        }
    }
}
