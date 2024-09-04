using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Models;
using Abby.DataAccess.Repository.IRepository;

namespace Abby.Web.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
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
            var objFromDb = _unitOfWork.CategoryRepository.GetFirstOrDefault(x => x.Id == Category.Id);
            if (objFromDb != null)
            {
                _unitOfWork.CategoryRepository.Remove(objFromDb);
                _unitOfWork.CategoryRepository.Save();
                TempData["success"] = "Category deleted successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
