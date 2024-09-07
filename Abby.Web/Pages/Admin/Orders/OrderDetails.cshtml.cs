using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
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
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public void OnGet(int id)
        {
			OrderHeader = _unitOfWork.OrderHeaderRepository.GetFirstOrDefault(filter:x => x.Id == id,
                includeProperties:$"{nameof(ApplicationUser)}");
            OrderDetails = _unitOfWork.OrderDetailRepository.GetAll(filter:x => x.OrderId == id).ToList();
		}
    }
}
