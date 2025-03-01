using DAL;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UI_Client.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            var categories = _service.GetAll();
            var existingCategory = categories.FirstOrDefault(x => x.Name.Trim().ToLower() == category.Name.Trim().ToLower());

            if (existingCategory != null)
            {
                ViewData["ErrorMessage"] = "Failed to add category. The name already exists.";
                return View(category);
            }

            if (ModelState.IsValid)
            {
                _service.Create(category);
                TempData["SuccessMessage"] = "Category added successfully!";
                return RedirectToAction("Index");
            }

            ViewData["ErrorMessage"] = "Failed to add category. Please check your input.";
            return View(category);
        }




        [HttpGet]
        public IActionResult Details(int? id)
        {
            var category = _service.GetById(id);    
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id) {
           
            var category = _service.GetById(id);
            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category) {

            if (ModelState.IsValid) { 
            
                _service.Edit(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id) {
            var category = _service.GetById(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {

                _service.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
