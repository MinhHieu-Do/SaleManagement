using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using WebApp.SaleManagement.ViewModels;

namespace WebApp.SaleManagement.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository,INotyfService notyf)
        {
            _notyf = notyf;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            return View(categories);
        }
        
        public IActionResult Filter(string searchString)
        {
            ViewData["currentFilter"] = searchString;
            var categories = _categoryRepository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(c => c.CategoryName.ToLower().Contains(searchString.ToLower()));
            }
            
            return PartialView("_ListCategory",categories);
        }
        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }


            var category = _categoryRepository.GetById(id);
            var model = new CategoryViewModel
            {
                Category = category,
                Products = _categoryRepository.GetProductsByCategory(category.Id)
            };

            return View(model);

        }

        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost, ActionName("CreatePost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Category model)
        {
            if (ModelState.IsValid)
            {
                if (model.CategoryDesc == null)
                    model.CategoryDesc = model.CategoryName;
                await _categoryRepository.AddAsync(model);
                _notyf.Success("Success");
                return RedirectToAction("Index");
            }
            _notyf.Error("Failed Please try again");
            return View("Create");
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return BadRequest();
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View("Edit",category);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Category model)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(model);
                _notyf.Success("Success");
                return RedirectToAction("Index");
            }
            _notyf.Error("Failed Try again");
            return View("Edit");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null && id == 0)
            {
                return NotFound();
            }

            return PartialView("_Delete",category);
        }

        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null && id == 0)
            {

                return NotFound();
            }
            _notyf.Success("Success");
            await _categoryRepository.DeleteAsync(category);
            return RedirectToAction("Index");
        }

    }
}
