using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Data;
using Abby.Models;

namespace Abby.Web.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;
        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IActionResult OnPost()
        {
            var objFromDb = _context.Categories.FirstOrDefault(x => x.Id == Category.Id);
            if (objFromDb != null)
            {
                _context.Categories.Remove(objFromDb);
                _context.SaveChanges();
                TempData["success"] = "Category deleted successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
