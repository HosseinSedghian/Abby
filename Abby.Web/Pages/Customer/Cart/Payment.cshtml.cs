using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Customer.Cart
{
	[Authorize(Roles = $"{SD.CustomerRole},{SD.ManagerRole}")]
	[BindProperties]
    public class PaymentModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public OrderHeader OrderHeader { get; set; }
        public void OnGet(int orderId)
        {
            OrderHeader = _unitOfWork.OrderHeaderRepository
                .GetFirstOrDefault(filter: x => x.Id == orderId,
                includeProperties: $"{nameof(OrderHeader)}.{OrderHeader.OrderDetails}");
        }

        public IActionResult OnPostPay()
        {
            return RedirectToPage("OrderConfirmation", new { id = OrderHeader.Id});
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Customer/Home/Index");
        }
    }
}
