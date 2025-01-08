using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.User
{
    [Authorize(Roles = "User")]
    public class UserPanelModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public string FullName { get; private set; }

        public UserPanelModel(UserManager<AppUser> userManager)
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