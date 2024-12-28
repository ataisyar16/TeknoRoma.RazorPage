using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Razorpage.Pages.Departmanlar
{
    public class UpdateModel : PageModel
    {
        private readonly IManager<Departman> _manager;

        public UpdateModel(IManager<Departman> manager)
        {
            _manager = manager;
        }

        [BindProperty]
        public InputModel EditModel { get; set; } = new();

        public List<Departman> Departmanlar { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var departman = await _manager.GetByIdAsync(id, default);
            if (departman == null) return NotFound();

            EditModel.Id = departman.Id;
            EditModel.DepartmanAdi = departman.DepartmanAdi;
            EditModel.UstId = departman.UstId;
            Departmanlar = (List<Departman>)await _manager.GetAllAsync(default);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var departman = new Departman
                {
                    Id = EditModel.Id,
                    DepartmanAdi = EditModel.DepartmanAdi,
                    UstId = EditModel.UstId
                };

                var result = await _manager.UpdateAsync(departman, default);
                if (result.Success) return RedirectToPage("Index");
            }

            Departmanlar = (List<Departman>)await _manager.GetAllAsync(default);
            return Page();
        }

        public class InputModel
        {
            public string Id { get; set; }

            [Required(ErrorMessage = "Departman adý zorunludur")]
            public string DepartmanAdi { get; set; }

            public string? UstId { get; set; }
        }
    }
}
