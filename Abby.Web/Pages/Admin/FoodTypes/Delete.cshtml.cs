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
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
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
            var objFromDb = _unitOfWork.FoodTypeRepository.GetFirstOrDefault(x => x.Id == FoodType.Id);
            if (objFromDb != null)
            {
                _unitOfWork.FoodTypeRepository.Remove(objFromDb);
                _unitOfWork.FoodTypeRepository.Save();
                TempData["success"] = "Food Type deleted successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
