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
    public class BrandController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IBrandRepository _brandRepository;
        public BrandController(INotyfService notyf, IBrandRepository brandRepository)
        {
            _notyf = notyf;
            _brandRepository = brandRepository;
        }
        public IActionResult Index()
        {
            var brands = _brandRepository.GetAll();
            return View(brands);
        }

        public IActionResult Filter(string searchString)
        {
            ViewData["currentFilter"] = searchString;
            var brands = _brandRepository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                brands = brands.Where(c => c.BrandName.ToLower().Contains(searchString.ToLower()));
            }

            return PartialView("_ListBrand", brands);
        }
        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }


            var brand = _brandRepository.GetById(id);
            if (brand == null)
                return NotFound();
            var model = new BrandViewModel
            {
                Brand = brand,
                Products = _brandRepository.GetProductsByBrand(brand.Id)
            };

            return View(model);

        }

        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost, ActionName("CreatePost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Brand model)
        {
            if (ModelState.IsValid)
            {
                if (model.BrandDesc == null)
                    model.BrandDesc = model.BrandName;
                await _brandRepository.AddAsync(model);
                _notyf.Success("Success");
                return RedirectToAction("Index");
            }
            _notyf.Error("Brand Name Invalid!");
            return View("Create");
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return BadRequest();
            var brand = _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View("Edit", brand);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Brand model)
        {
            if (ModelState.IsValid)
            {
                await _brandRepository.UpdateAsync(model);
                _notyf.Success("Success");
                return RedirectToAction("Index");
            }
            _notyf.Error("Brand Name Invalid!");
            return View("Edit");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            var brand = _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", brand);
        }

        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (id == 0)
                return BadRequest();
            var brand = _brandRepository.GetById(id);
            if (brand == null)
            {

                return NotFound();
            }

            await _brandRepository.DeleteAsync(brand);
            _notyf.Success("Delete success");
            return RedirectToAction("Index");
        }
    }
}
