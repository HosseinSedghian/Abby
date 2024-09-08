using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Abby.Web.Pages.Customer.Cart
{
	[Authorize(Roles = $"{SD.CustomerRole},{SD.ManagerRole}")]
	[BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public double CartTotal { get; set; }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCarts = _unitOfWork.ShoppingCartRepository.GetAll(filter: x => x.ApplicationUserId == claim.Value,
                includeProperties: $"{nameof(MenuItem)},{nameof(MenuItem)}.{nameof(MenuItem.Category)},{nameof(MenuItem)}.{nameof(MenuItem.FoodType)}",
                orderby: x => x.OrderBy(x => x.Count)).ToList();

                CartTotal = ShoppingCarts.Sum(x => x.Count * x.MenuItem.Price);
            }
        }
        public IActionResult OnPostPlus(int cartId)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCartRepository.GetFirstOrDefault(x => x.Id == cartId);
            if(cartFromDb == null)
            {
                return Page();
            }
            else
            {
                _unitOfWork.ShoppingCartRepository.IncrementCount(ref cartFromDb, 1);
                _unitOfWork.ShoppingCartRepository.Update(cartFromDb);
                _unitOfWork.ShoppingCartRepository.Save();
                TempData["succes"] = "Shopping cart increased successfully.";
                return RedirectToPage(nameof(Index));
            }
        }
        public IActionResult OnPostMinus(int cartId)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCartRepository.GetFirstOrDefault(x => x.Id == cartId);
            if (cartFromDb == null)
            {
                return Page();
            }
            else
            {
                _unitOfWork.ShoppingCartRepository.DecrementCount(ref cartFromDb, 1);
                if(cartFromDb.Count <= 0)
                {
                    _unitOfWork.ShoppingCartRepository.Remove(cartFromDb);
                }
                else
                {
                    _unitOfWork.ShoppingCartRepository.Update(cartFromDb);
                }
                _unitOfWork.ShoppingCartRepository.Save();
                int cartCount = _unitOfWork.ShoppingCartRepository
                    .GetAll(x => x.ApplicationUserId == cartFromDb.ApplicationUserId).Count();
                HttpContext.Session.SetInt32(SD.CartCountKey, cartCount);
                TempData["succes"] = "Shopping cart decreased successfully.";
                return RedirectToPage(nameof(Index));
            }
        }
        public IActionResult OnPostRemove(int cartId)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCartRepository.GetFirstOrDefault(x => x.Id == cartId);
            if (cartFromDb == null)
            {
                return Page();
            }
            else
            {
                _unitOfWork.ShoppingCartRepository.Remove(cartFromDb);
                _unitOfWork.ShoppingCartRepository.Save();
                int cartCount = _unitOfWork.ShoppingCartRepository
                    .GetAll(x => x.ApplicationUserId == cartFromDb.ApplicationUserId).Count();
                HttpContext.Session.SetInt32(SD.CartCountKey, cartCount);
                TempData["succes"] = "Shopping cart deleted successfully.";
                return RedirectToPage(nameof(Index));
            }
        }
    }
}
