using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Abby.Web.Pages.Customer.Home
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MenuItem MenuItem { get; set; }
        [Range(1, 100, ErrorMessage = "Please select a count between 1 and 100.")]
        public int Count { get; set; }
        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItemRepository
                .GetFirstOrDefault(filter:x => x.Id == id,
                includeProperties:$"{nameof(Category)},{nameof(FoodType)}");

        }
    }
}
