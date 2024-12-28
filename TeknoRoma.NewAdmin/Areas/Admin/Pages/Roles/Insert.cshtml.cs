using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeknoRoma.NewAdmin.Areas.Admin.Pages.Roles
{
    public class InsertModel(RoleManager<IdentityRole> roleManager) : PageModel
    {

        [BindProperty]
        public IdentityRole Role { get; set; } = new IdentityRole();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await roleManager.CreateAsync(Role);
            if (result.Succeeded)
            {
                return RedirectToPage("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page();
            }
        }
    }
}
