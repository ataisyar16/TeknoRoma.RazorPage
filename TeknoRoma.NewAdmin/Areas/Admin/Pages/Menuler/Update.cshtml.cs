using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Menuler
{
    public class UpdateModel(IManager<Menu> menuManager) : PageModel
    {
        [BindProperty]
        public MenuVM MenuUpdateVM { get; set; } = new();
        public async Task OnGet(string id)
        {
            //    menuManager.GetByIdAsync(id, default).ContinueWith(task =>
            //    {
            //        var menu = task.Result;
            //        MenuUpdateVM.Id = menu.Id.ToString();
            //        MenuUpdateVM.MenuAdi = menu.MenuAdi;
            //        MenuUpdateVM.Page = menu.Page;
            //        MenuUpdateVM.Icon = menu.Icon;
            //        MenuUpdateVM.Css = menu.Css;
            //        MenuUpdateVM.Area = menu.Area;
            //        MenuUpdateVM.Title = menu.Title;
            //        MenuUpdateVM.Description = menu.Description;
            //    });

            var menu = await menuManager.GetByIdAsync(id, default);
            MenuUpdateVM.Id = menu.Id.ToString();
            MenuUpdateVM.MenuAdi = menu.MenuAdi;
            MenuUpdateVM.Page = menu.Page;
            MenuUpdateVM.Icon = menu.Icon;
            MenuUpdateVM.Css = menu.Css;
            MenuUpdateVM.Area = menu.Area;
            MenuUpdateVM.Title = menu.Title;
            MenuUpdateVM.Description = menu.Description;
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Menu menu = new();
            menu.MenuAdi = MenuUpdateVM.MenuAdi;
            menu.Page = MenuUpdateVM.Page;
            menu.Icon = MenuUpdateVM.Icon;
            menu.Css = MenuUpdateVM.Css;
            menu.Area = MenuUpdateVM.Area;
            menu.Title = MenuUpdateVM.Title;
            menu.Description = MenuUpdateVM.Description;
            var result = await menuManager.UpdateAsync(menu, default);
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
            public string Id { get; set; }
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
