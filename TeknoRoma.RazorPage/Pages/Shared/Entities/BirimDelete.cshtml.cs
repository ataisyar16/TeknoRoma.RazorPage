using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Concrete;
using TeknoRoma.DAL.DAL.Contexts;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.RazorPage.Pages.Entities
{
    public class BirimDeleteModel : PageModel
    {
        private readonly Manager<Birim> _birimManager;

        public BirimDeleteModel(AppDbContext context)
        {
            _birimManager = new Manager<Birim>(context);
        }

        [BindProperty]
        public string Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var birim = await _birimManager.GetByIdAsync(Id, CancellationToken.None);
            if (birim != null)
            {
                await _birimManager.DeleteAsync(birim, CancellationToken.None);
            }

            return RedirectToPage("./Birim");
        }
    }
}
