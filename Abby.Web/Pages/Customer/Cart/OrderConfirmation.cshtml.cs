using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Utility;

namespace Abby.Web.Pages.Customer.Cart
{
    [Authorize]
    [BindProperties]
    public class OrderConfirmationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderConfirmationModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int OrderId { get; set; }
        public void OnGet(int id)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(x => x.Id == id);
            orderHeader.TransactionId = Guid.NewGuid().ToString();
            orderHeader.Status = SD.StatusSubmitted;
            _unitOfWork.OrderHeaderRepository.Update(orderHeader);
            _unitOfWork.OrderHeaderRepository.Save();
            OrderId = id;
        }
    }
}
