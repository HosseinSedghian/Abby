using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Web.Pages.Admin.MenuItems
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DeleteModel(IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public MenuItem MenuItem { get; set; }
        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItemRepository
                .GetFirstOrDefault(filter:x => x.Id == id,
                        includeProperties:$"{nameof(Category)},{nameof(FoodType)}");
        }

        public IActionResult OnPost()
        {
            var objFromDb = _unitOfWork.MenuItemRepository
                .GetFirstOrDefault(x => x.Id == MenuItem.Id);
            if (objFromDb != null)
            {
                if(objFromDb.ImageUrl != null)
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string fullPath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
                    if(System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                _unitOfWork.MenuItemRepository.Remove(objFromDb);
                _unitOfWork.MenuItemRepository.Save();
                TempData["success"] = "Menu item deleted successfully.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
