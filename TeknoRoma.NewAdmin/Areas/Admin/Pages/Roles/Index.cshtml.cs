using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.NewAdmin.Areas.Admin.Pages.Roles
{
    public class IndexModel(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager) : PageModel
    {


        [BindProperty]
        public List<RoleViewModel> RolesVM { get; set; } = new();
        public async Task OnGet()
        {

            var roles = await roleManager.Roles.ToListAsync();

            foreach (var role in roles)
            {
                RoleViewModel model = new();
                model.Role = role;
                var roleUsers = await userManager.GetUsersInRoleAsync(role.Name);
                foreach (var user in roleUsers)
                {
                    model.UserNames.Add(user.UserName);
                }

                RolesVM.Add(model);
            }



        }

        public class RoleViewModel
        {
            public IdentityRole Role { get; set; }
            public List<string> UserNames { get; set; } = new();
        }

        public IActionResult OnPostCreateRole(string RoleName)
        {
            var role = new IdentityRole(RoleName);
            var result = roleManager.CreateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToPage();
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
