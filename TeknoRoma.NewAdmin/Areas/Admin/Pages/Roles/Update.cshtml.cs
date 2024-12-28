using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeknoRoma.NewAdmin.Areas.Admin.Pages.Roles
{
    public class UpdateModel(RoleManager<IdentityRole> roleManager) : PageModel
    {
        [BindProperty]
        public IdentityRole? Role { get; set; }
        public async Task OnGet(string Id)
        {
            Role = await roleManager.FindByIdAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            var role = await roleManager.FindByIdAsync(Role.Id);
            role.Name = Role.Name;
            var result = await roleManager.UpdateAsync(role);
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

        //public async Task<IActionResult> OnPostUpdateRole(string Id, string RoleName)
        //{
        //    var role = await roleManager.FindByIdAsync(Id);
        //    role.Name = RoleName;
        //    var result = await roleManager.UpdateAsync(role);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToPage();
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //        return Page();
        //    }
        //}
    }
}
