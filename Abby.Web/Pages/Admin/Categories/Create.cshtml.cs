using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Data;
using Abby.Models;

namespace Abby.Web.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        public Category Category { get; set; }
        public void OnGet()
        {
            Category = new Category();
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(Category);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
