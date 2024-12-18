using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Concrete;
using TeknoRoma.DAL.DAL.Contexts;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.RazorPage.Pages.Entities
{
    public class BirimEditModel : PageModel
    {
        private readonly Manager<Birim> _birimManager;

        public BirimEditModel(AppDbContext context)
        {
            _birimManager = new Manager<Birim>(context);
        }

        [BindProperty]
        public Birim Birim { get; set; }

        public async Task OnGetAsync(string id)
        {
            Birim = await _birimManager.GetByIdAsync(id, CancellationToken.None);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _birimManager.UpdateAsync(Birim, CancellationToken.None);
            return RedirectToPage("./Birim");
        }
    }
}
