using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public FoodType FoodType { get; set; }
        public void OnGet()
        {
            FoodType = new FoodType();
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.FoodTypeRepository.Add(FoodType);
                _unitOfWork.FoodTypeRepository.Save();
                TempData["success"] = "Food Type created successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
