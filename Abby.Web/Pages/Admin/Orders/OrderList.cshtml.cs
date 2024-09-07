using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Abby.Web.Pages.Admin.Orders
{
    [Authorize(Roles = $"{SD.ManagerRole},{SD.FrontDeskRole},{SD.CustomerRole}")]
    [BindProperties]
    public class OrderListModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderListModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OrderHeader> OrderHeaders { get; set; }
        public void OnGet()
        {
            if(User.IsInRole(SD.ManagerRole) || User.IsInRole(SD.FrontDeskRole))
            {
                OrderHeaders = _unitOfWork.OrderHeaderRepository
                .GetAll(includeProperties: $"{nameof(ApplicationUser)}").ToList();
            }
            if(User.IsInRole(SD.CustomerRole))
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                OrderHeaders = _unitOfWork.OrderHeaderRepository
                .GetAll(includeProperties: $"{nameof(ApplicationUser)}",
                        filter:x => x.ApplicationUserId == claim.Value).ToList();
            }
        }
    }
}
