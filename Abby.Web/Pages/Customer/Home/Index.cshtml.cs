using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Customer.Home
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<MenuItem> MenuItems { get; set; }
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItemRepository
                .GetAll(includeProperties: $"{nameof(MenuItem.Category)},{nameof(MenuItem.FoodType)}")
                .ToList();
            Categories = _unitOfWork.CategoryRepository
                .GetAll(orderby:c => c.OrderBy(u => u.DisplayOrder)).ToList();
        }
    }
}
