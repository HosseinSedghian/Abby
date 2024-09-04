using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.Web.Pages.Admin.MenuItems
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
        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItemRepository
                .GetAll(includeProperties:$"{nameof(MenuItem.Category)},{nameof(MenuItem.FoodType)}")
                .ToList();
        }
    }
}
