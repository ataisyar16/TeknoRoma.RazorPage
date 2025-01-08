using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Account
{
    public class LogoutModel(SignInManager<AppUser> signInManager) : PageModel
    {
        public async Task OnGet()
        {
            signInManager.SignOutAsync();
            Response.Redirect("/Index");
        }
    }
}



