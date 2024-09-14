using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Abby.Web.Pages.Customer.Home
{
    [BindProperties]
    [Authorize(Roles = $"{SD.CustomerRole},{SD.ManagerRole}")]
    public class AddToCartModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddToCartModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ShoppingCart ShoppingCart { get; set; }
        public void OnGet(int id)
        {
            ShoppingCart = new ShoppingCart();
            ShoppingCart.MenuItem = _unitOfWork.MenuItemRepository
                .GetFirstOrDefault(filter:x => x.Id == id,
                includeProperties:$"{nameof(Category)},{nameof(FoodType)}");
            ShoppingCart.MenuItemId = ShoppingCart.MenuItem.Id;
        }
        public IActionResult OnPost()
        {
            ModelState.Remove($"{nameof(ShoppingCart)}.{nameof(MenuItem)}");
            ModelState.Remove($"{nameof(ShoppingCart)}.{nameof(ApplicationUser)}");
            ModelState.Remove($"{nameof(ShoppingCart)}.{nameof(ShoppingCart.ApplicationUserId)}");

            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                ShoppingCart.ApplicationUserId = claim.Value;

                var cartFromDb = _unitOfWork.ShoppingCartRepository.GetFirstOrDefault(filter: x =>
                        x.ApplicationUserId == claim.Value && x.MenuItemId == ShoppingCart.MenuItemId);
                if (cartFromDb != null)
                {
                    _unitOfWork.ShoppingCartRepository.IncrementCount(ref cartFromDb, ShoppingCart.Count);
                    _unitOfWork.ShoppingCartRepository.Update(cartFromDb);
                }
                else
                {
                    _unitOfWork.ShoppingCartRepository.Add(ShoppingCart);
                }
                _unitOfWork.ShoppingCartRepository.Save();
                int cartCount = _unitOfWork.ShoppingCartRepository
                    .GetAll(x => x.ApplicationUserId == claim.Value).Count();
                HttpContext.Session.SetInt32(SD.CartCountKey, cartCount);
                TempData["success"] = "Shopping cart added successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
