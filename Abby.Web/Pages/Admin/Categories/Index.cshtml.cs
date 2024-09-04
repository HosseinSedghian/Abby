using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Abby.DataAccess.Repository.IRepository;

namespace Abby.Web.Pages.Admin.Categories
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Category> _Categories;
        public void OnGet()
        {
            _Categories = _unitOfWork.CategoryRepository.GetAll().ToList();
        }
    }
}
