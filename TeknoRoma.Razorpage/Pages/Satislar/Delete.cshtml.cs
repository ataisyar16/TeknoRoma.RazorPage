using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Satislar
{
    public class DeleteModel(IManager<Satis> manager) : PageModel
    {
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var satis = await manager.GetByIdAsync(id, default);
            if (satis == null)
            {
                return NotFound();
            }

            var result = await manager.DeleteAsync(satis, default);
            if (result.Success)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
