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
        public List<Category> Categories { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public void OnGet(int? shoppingCartId)
        {
            Categories = _unitOfWork.CategoryRepository
                .GetAll(orderby:c => c.OrderBy(u => u.DisplayOrder),
                        includeProperties:$"{nameof(Category.MenuItems)}," +
                        $"{nameof(Category.MenuItems)}.{nameof(FoodType)}").ToList();
            if (shoppingCartId != null)
            {
                ShoppingCart = _unitOfWork.ShoppingCartRepository
                    .GetFirstOrDefault(filter:x => x.Id == shoppingCartId,
                                    includeProperties:$"{nameof(ShoppingCart.MenuItem)}");
			}
        }
    }
}
