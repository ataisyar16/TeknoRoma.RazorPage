using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public string FullName { get; private set; }

        public AdminPanelModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                FullName = user.FullName;
            }
        }
    }
}