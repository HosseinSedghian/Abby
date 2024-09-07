using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Models;
using Abby.DataAccess.Repository.IRepository;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;

namespace Abby.Web.Pages.Admin.Categories
{
    [Authorize(Roles = SD.ManagerRole)]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                _unitOfWork.CategoryRepository.Add(Category);
                _unitOfWork.CategoryRepository.Save();
                TempData["success"] = "Category created successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
