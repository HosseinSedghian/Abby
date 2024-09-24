using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Admin.Users
{
    [BindProperties]
    [Authorize(Roles = SD.ManagerRole)]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public void OnGet()
        {
            ApplicationUsers = _unitOfWork.ApplicationUserRepository
                .GetAll().ToList();
        }
    }
}
