using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel ModelInput { get; set; } = new();

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
            }
            var user = await _userManager.FindByNameAsync(ModelInput.FullName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanýcý bulunamadý.");
                return Page();
            }
            var result = await _signInManager.PasswordSignInAsync(user, ModelInput.Password, true, false);
            if (result.Succeeded)
            {
                // Kullanýcýnýn rolüne göre yönlendirme
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToPage("/Admin/AdminPanel");
                }
                else if (await _userManager.IsInRoleAsync(user, "User"))
                {
                    return RedirectToPage("/User/UserPanel");
                }
                return RedirectToPage("/Index");
            }
            ModelState.AddModelError(string.Empty, "Geçersiz giriþ denemesi.");
            return Page();
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Full Name zorunludur.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Þifre zorunludur.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
