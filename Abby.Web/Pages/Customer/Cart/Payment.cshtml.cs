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
        public List<OrderDetail> OrderDetails { get; set; }
        public void OnGet(int orderId)
        {
            OrderHeader = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);
            OrderDetails = _unitOfWork.OrderDetailRepository.GetAll(x => x.OrderId == orderId).ToList();
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
