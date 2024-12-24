using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Account
{
    public class RegisterModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : PageModel
    {


        [BindProperty]
        public InputModel ModelInput { get; set; } = new();
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            var user = new AppUser
            {
                UserName = ModelInput.Email,
                Email = ModelInput.Email,
                TcNo = ModelInput.TcNo
            };
            var result = await userManager.CreateAsync(user, ModelInput.Password);
            if (result.Succeeded)
            {
                var role = await roleManager.FindByNameAsync("User");
                if (role == null)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = "User" });
                }
                await userManager.AddToRoleAsync(user, "User");

                return RedirectToPage("/Account/Login");
            }

            return Page();
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Email Alani Zorunludur")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }


            [Required(ErrorMessage = "Tcno Alani Zorunludur")]
            [Length(11, 11, ErrorMessage = "Tcno 11 karakter olmalidir")]
            public string TcNo { get; set; }

            [Required(ErrorMessage = "Þifre Alani Zorunludur")]
            [DataType(DataType.Password)]

            public string Password { get; set; }

            [Required(ErrorMessage = "Þifre Alani Zorunludur")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Uyumsuz þifre")]
            public string RePassword { get; set; }
        }
    }
}
