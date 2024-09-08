using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Models.ViewModels;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Admin.Orders
{
    [BindProperties]
    [Authorize(Roles = $"{SD.ManagerRole},{SD.KitchenRole}")]
    public class ChefManagementModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChefManagementModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OrderDetailsVM> OrderDetailsVMs { get; set; }
        public void OnGet()
        {
			OrderDetailsVMs = new List<OrderDetailsVM>();
            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeaderRepository
                .GetAll(x => x.Status == SD.StatusSubmittedPaymentApproved || x.Status == SD.StatusInProccess).ToList();
            foreach (OrderHeader od in orderHeaders)
            {
                OrderDetailsVM odVM = new OrderDetailsVM()
                {
                    OrderHeader = od,
                    OrderDetails = _unitOfWork.OrderDetailRepository
                        .GetAll(x => x.OrderId == od.Id).ToList()
                };
                OrderDetailsVMs.Add(odVM);
			}
		}
        public IActionResult OnPostOrderInProcess(int orderId)
        {
            OrderHeader objFromDb = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);
            objFromDb.Status = SD.StatusInProccess;
            _unitOfWork.OrderHeaderRepository.Update(objFromDb);
            _unitOfWork.OrderHeaderRepository.Save();
            return RedirectToPage();
        }
        public IActionResult OnPostOrderReady(int orderId)
        {
            OrderHeader objFromDb = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);
            objFromDb.Status = SD.StatusReadyForPickup;
            _unitOfWork.OrderHeaderRepository.Update(objFromDb);
            _unitOfWork.OrderHeaderRepository.Save();
            return RedirectToPage();
        }
        public IActionResult OnPostOrderCancel(int orderId)
        {
            OrderHeader objFromDb = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == orderId);
            objFromDb.Status = SD.StatusCancelled;
            _unitOfWork.OrderHeaderRepository.Update(objFromDb);
            _unitOfWork.OrderHeaderRepository.Save();
            return RedirectToPage();
        }
    }
}
