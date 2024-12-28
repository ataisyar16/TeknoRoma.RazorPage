using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Menuler
{
    public class DeleteModel(IManager<Menu> menuManager) : PageModel
    {
        [BindProperty]
        public Menu MenuToDelete { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            MenuToDelete = await menuManager.GetByIdAsync(id, default);

            if (MenuToDelete == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (MenuToDelete == null)
            {
                return RedirectToPage("Index");
            }

            var result = await menuManager.DeleteAsync(MenuToDelete, default);

            if (result.Success)
            {
                return RedirectToPage("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Message);
            }

            return Page();
        }
    }
}
