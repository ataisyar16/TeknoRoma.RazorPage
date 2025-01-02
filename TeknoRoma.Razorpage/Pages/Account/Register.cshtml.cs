using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.Entities.Entities.Concrete;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace TeknoRoma.Razorpage.Pages.Account
{
    public class RegisterModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager) : PageModel
    {


        [BindProperty]
        public InputModel ModelInput { get; set; } = new();

        public class InputModel
        {
            [System.ComponentModel.DataAnnotations.Required]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string TcNo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string RePassword { get; set; }

            [Required]
            public string UserType { get; set; }
        }

        public List<string> UserTypes { get; set; } = new() { "Admin", "User" };

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new AppUser
            {
                UserName = ModelInput.Email,
                FullName = ModelInput.FullName,
                Email = ModelInput.Email,
                TcNo = ModelInput.TcNo,
                UserType = ModelInput.UserType
            };

            var result = await userManager.CreateAsync(user, ModelInput.Password);

            if (result.Succeeded)
            {
                var role = ModelInput.UserType;

                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                // Rol atama iþlemi
                if (ModelInput.UserType == "Admin")
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "User");
                }

                // Kullanýcý giriþ iþlemi
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
