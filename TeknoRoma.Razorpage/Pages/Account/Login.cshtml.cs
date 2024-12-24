using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Account
{
    public class LoginModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : PageModel
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
            var user = await userManager.FindByEmailAsync(ModelInput.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanici Bulunamadi");
                return Page();
            }
            var result = await signInManager.PasswordSignInAsync(user, ModelInput.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToPage("/Admin/Users/Index");
            }
            ModelState.AddModelError("", "Kullanici Bulunamadi");
            return Page();
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Email Zorunludur")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }


            [Required(ErrorMessage = "Þifre Zorunludur")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
