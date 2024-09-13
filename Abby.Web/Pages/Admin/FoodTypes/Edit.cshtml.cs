using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Admin.FoodTypes
{
    [Authorize(Roles = SD.ManagerRole)]
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public FoodType FoodType { get; set; }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodTypeRepository.GetFirstOrDefault(x => x.Id == id);
        }
        public IActionResult OnPost()
        {
            ModelState.Remove($"{nameof(FoodType)}.{nameof(FoodType.MenuItems)}");
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodTypeRepository.Update(FoodType);
                _unitOfWork.FoodTypeRepository.Save();
                TempData["success"] = "Food Type updated successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
