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
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
        }
        public IActionResult OnPost()
        {
            ModelState.Remove($"{nameof(Category)}.{nameof(Category.MenuItems)}");
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(Category);
                _unitOfWork.CategoryRepository.Save();
                TempData["success"] = "Category updated successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
