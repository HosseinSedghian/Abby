using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abby.Web.Pages.Admin.MenuItems
{
    [Authorize(Roles = SD.ManagerRole)]
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpsertModel(IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public MenuItem MenuItem { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> FoodTypeList { get; set; }
        public void OnGet(int? id)
        {
            CategoryList = _unitOfWork.CategoryRepository.GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            FoodTypeList = _unitOfWork.FoodTypeRepository.GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            if (id == null || id == 0)
            {
                MenuItem = new MenuItem();
            }
            else
            {
                MenuItem = _unitOfWork.MenuItemRepository.GetFirstOrDefault(x => x.Id == id);
            }
        }
        public IActionResult OnPost()
        {
            ModelState.Remove($"{nameof(MenuItem)}.{nameof(Category)}");
            ModelState.Remove($"{nameof(MenuItem)}.{nameof(FoodType)}");
            ModelState.Remove($"{nameof(MenuItem)}.{nameof(MenuItem.ImageUrl)}");
            ModelState.Remove($"{nameof(MenuItem)}.{nameof(MenuItem.OrderDetails)}");
            ModelState.Remove($"{nameof(MenuItem)}.{nameof(MenuItem.ShoppingCarts)}");

            var files = HttpContext.Request.Form.Files;
            if(MenuItem.Id == 0 && files.Count == 0)
            {
                ModelState.AddModelError("", "Please insert an image.");
            }

            if (files.Count > 0)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var upload = Path.Combine(webRootPath, @"images\menuitems");
                if (!System.IO.Directory.Exists(upload))
                {
                    System.IO.Directory.CreateDirectory(upload);
                }
                string filename_new = Guid.NewGuid().ToString();
                
                var extension = Path.GetExtension(files[0].FileName);
                string serverFilePath = Path.Combine(upload, $"{filename_new}{extension}");
                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                if(MenuItem.ImageUrl != null)
                {
                    string oldImageUrl = Path.Combine(webRootPath, MenuItem.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImageUrl))
                    {
                        System.IO.File.Delete(oldImageUrl);
                    }
                }
                MenuItem.ImageUrl = $@"\images\menuitems\{filename_new}{extension}";
            }         
            if (ModelState.IsValid)
            {
                if (MenuItem.Id == 0)
                {
                    // Create
                    _unitOfWork.MenuItemRepository.Add(MenuItem);
                    _unitOfWork.MenuItemRepository.Save();
                    TempData["success"] = "Menu item created successfully.";
                    return RedirectToPage(nameof(Index));
                }
                else
                {
                    // Update
                    _unitOfWork.MenuItemRepository.Update(MenuItem);
                    _unitOfWork.MenuItemRepository.Save();
                    TempData["success"] = "Menu item updated successfully.";
                    return RedirectToPage(nameof(Index));
                }
            }
            return Page();
        }
    }
}
