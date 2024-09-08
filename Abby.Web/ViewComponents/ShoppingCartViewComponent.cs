using Abby.DataAccess.Repository.IRepository;
using Abby.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Abby.Web.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int count = 0;
            if (claim != null)
            {
                if(HttpContext.Session.GetInt32(SD.CartCountKey) != null)
                {
                    count = HttpContext.Session.GetInt32(SD.CartCountKey) ?? 0;
                }
                else
                {
                    count = _unitOfWork.ShoppingCartRepository
                        .GetAll(x => x.ApplicationUserId == claim.Value).Count();
                }
            }
            return View(count);
        }
    }
}
