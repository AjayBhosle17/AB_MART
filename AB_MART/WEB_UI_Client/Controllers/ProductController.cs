using DAL;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UI_Client.Controllers
{
    
    public class ProductController : Controller
    {
        IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _service.GetAll();
            return View(products);
        }

        [HttpGet]

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
          

            if (ModelState.IsValid)
            {
                _service.Create(product);
                
                return RedirectToAction("Index");
            }

            ViewData["ErrorMessage"] = "Failed to add Product. Please check your input.";
            return View(product);
        }




        [HttpGet]
        public IActionResult Details(int? id)
        {
            var product = _service.GetById(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var product = _service.GetById(id);
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {

            if (ModelState.IsValid)
            {

                _service.Edit(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var product = _service.GetById(id);
            return View(product);
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
