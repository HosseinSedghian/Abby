using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Abby.Utility;
namespace Abby.Web.Pages.Customer.Cart
{
	[Authorize(Roles = $"{SD.CustomerRole},{SD.ManagerRole}")]
	[BindProperties]
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCarts = _unitOfWork.ShoppingCartRepository.GetAll(filter: x => x.ApplicationUserId == claim.Value,
                includeProperties:$"{nameof(MenuItem)}").ToList();

            OrderHeader = new OrderHeader();
            OrderHeader.OrderTotalPrice = ShoppingCarts.Sum(x => x.MenuItem.Price * x.Count);
            var user = _unitOfWork.ApplicationUserRepository.GetFirstOrDefault(x => x.Id == claim.Value);
            OrderHeader.PickupName = $"{user.FirstName} {user.LastName}";
            OrderHeader.PhoneNumber = user.PhoneNumber;
        }
        public IActionResult OnPost()
        {
            ModelState.Remove($"{nameof(OrderHeader)}.{nameof(ApplicationUser)}");
            ModelState.Remove($"{nameof(OrderHeader)}.{nameof(OrderHeader.Status)}");
            ModelState.Remove($"{nameof(OrderHeader)}.{nameof(OrderHeader.ApplicationUserId)}");

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid && claim != null)
            {
                ShoppingCarts = _unitOfWork.ShoppingCartRepository.GetAll(filter: x => x.ApplicationUserId == claim.Value,
                includeProperties: $"{nameof(MenuItem)}").ToList();
                OrderHeader.OrderTotalPrice = ShoppingCarts.Sum(x => x.MenuItem.Price * x.Count);
                OrderHeader.Status = SD.StatusPendingPayment;
                OrderHeader.OrderDate = DateTime.Now;
                OrderHeader.ApplicationUserId = claim.Value;
                OrderHeader.PickupTime = Convert.ToDateTime(OrderHeader.PickupDate.ToShortDateString() + " " +
                    OrderHeader.PickupTime.ToShortTimeString());

                _unitOfWork.OrderHeaderRepository.Add(OrderHeader);
                _unitOfWork.OrderHeaderRepository.Save();

                foreach(var cart in ShoppingCarts)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.OrderId = OrderHeader.Id;
                    obj.MenuItemId = cart.MenuItemId;
                    obj.MenuItemPrice = cart.MenuItem.Price;
                    obj.Count = cart.Count;
                    obj.MenuItemName = cart.MenuItem.Name;
                    _unitOfWork.OrderDetailRepository.Add(obj);
                    _unitOfWork.OrderDetailRepository.Save();
                }
                _unitOfWork.ShoppingCartRepository.RemoveRange(ShoppingCarts);
                _unitOfWork.ShoppingCartRepository.Save();
                return RedirectToPage("Payment", new { orderId = OrderHeader.Id});
            }
            return Page();
        }
    }
}
