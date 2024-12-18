using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Concrete;
using TeknoRoma.DAL.DAL.Contexts;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.RazorPage.Pages.Entities
{
    public class BirimAddModel : PageModel
    {
        private readonly Manager<Birim> _birimManager;

        public BirimAddModel(AppDbContext context)
        {
            _birimManager = new Manager<Birim>(context);
        }

        [BindProperty]
        public Birim Birim { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _birimManager.InsertAsync(Birim, CancellationToken.None);
            return RedirectToPage("./Birim");
        }
    }
}
