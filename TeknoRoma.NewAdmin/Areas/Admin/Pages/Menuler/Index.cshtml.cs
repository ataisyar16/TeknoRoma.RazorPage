using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Menuler
{
    public class IndexModel(IManager<Menu> menuManager) : PageModel
    {

        [BindProperty]
        public List<MenuVM> MenusVM { get; set; } = new();

        public async Task OnGet()
        {
            var menus = await menuManager.GetAllIncludeAsync(default, null, p => p.Parent).Result.ToListAsync();
            foreach (var menu in menus)
            {
                MenuVM model = new();
                model.Id = menu.Id.ToString();
                model.MenuAdi = menu.MenuAdi;
                model.Page = menu.Page;
                model.Icon = menu.Icon;
                model.Css = menu.Css;
                model.Area = menu.Area;
                model.Title = menu.Title;
                model.Description = menu.Description;
                model.ParentId = menu.ParentId;
                model.Parent = menu.Parent;
                MenusVM.Add(model);
            }
        }

        public class MenuVM
        {
            public string Id { get; set; }
            public string MenuAdi { get; set; }
            public string? Page { get; set; }
            public string? Icon { get; set; }
            public string? Css { get; set; }
            public string? Area { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public string? ParentId { get; set; }
            public Menu? Parent { get; set; }
        }
    }
}
