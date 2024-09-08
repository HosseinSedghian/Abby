using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Models.ViewModels;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Admin.Orders
{
    [Authorize(Roles = $"{SD.ManagerRole},{SD.FrontDeskRole},{SD.CustomerRole}")]
    [BindProperties]
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public OrderDetailsVM OrderDetailsVM { get; set; }
        public void OnGet(int id)
        {
            OrderDetailsVM = new OrderDetailsVM()
            {
                OrderHeader = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(filter: x => x.Id == id,
                        includeProperties: $"{nameof(ApplicationUser)}"),
                OrderDetails = _unitOfWork.OrderDetailRepository.GetAll(filter: x => x.OrderId == id).ToList()
            };
        }
        public IActionResult OnPostPayNow(int id)
        {
            return RedirectToPage("/Customer/Cart/Payment", new { orderId = id });
        }
        public IActionResult OnPostOrderCompleted(int orderId)
        {
            OrderHeader objFromDb = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);
            objFromDb.Status = SD.StatusCompleted;
            _unitOfWork.OrderHeaderRepository.Update(objFromDb);
            _unitOfWork.OrderHeaderRepository.Save();
            return RedirectToPage("OrderList");
        }
        public IActionResult OnPostOrderRefund(int orderId)
        {
            OrderHeader objFromDb = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);
            
            // Here we should pay back money to the customer.

            objFromDb.Status = SD.StatusRefunded;
            _unitOfWork.OrderHeaderRepository.Update(objFromDb);
            _unitOfWork.OrderHeaderRepository.Save();
            return RedirectToPage("OrderList");
        }
        public IActionResult OnPostOrderCancel(int orderId)
        {
            OrderHeader objFromDb = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);

            // Here we should pay back money to the customer.

            objFromDb.Status = SD.StatusCancelled;
            _unitOfWork.OrderHeaderRepository.Update(objFromDb);
            _unitOfWork.OrderHeaderRepository.Save();
            return RedirectToPage("OrderList");
        }
    }
}
