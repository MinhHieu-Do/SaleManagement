using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using WebApp.SaleManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.SaleManagement.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository, INotyfService notyf)
        {
            _notyf = notyf;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetProductIndex();
            
            return View(products);
        }

        public IActionResult Filter(string searchString)
        {
            ViewData["currentFilter"] = searchString;
            var products = _productRepository.GetProductIndex();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(c => c.ProductName.ToLower().Contains(searchString.ToLower()));
            }

            return PartialView("_ListProduct", products);
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_brandRepository.GetAll().ToList(), "Id", "BrandName");

            ViewData["Categories"] = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName"); 
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product,IFormFile formFile)
        {
            if (ModelState.IsValid)
            {

                if (product.ImageFile != null)
                {
                    string folder = $"UploadFiles/Images/Products/{DateTime.Now:yyyyMMdd}/";
                    product.Image = ImageUtils.UploadFileImage(product.ImageFile, folder);
                }
                await _productRepository.AddAsync(product);
                _notyf.Success("Success");
                return RedirectToAction(nameof(Index));

            }
            ViewData["Brands"] = new SelectList(_brandRepository.GetAll().ToList(), "Id", "BrandName",product.BrandId);
            ViewData["Categories"] = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName",product.CategoryId);
            return View("Create");
        }

        //Description imgage
        [HttpPost]
        public IActionResult UploadImage(List<IFormFile> formFiles)
        {
            string path = "";
            if (formFiles != null)
            {
                foreach (var formFile in Request.Form.Files)
                {
                    string folder = $"UploadFiles/Images/Products/Description/";
                    path = ImageUtils.UploadFileImage(formFile, folder);
                }
            }
            string filePath = "https://localhost:44325/" + path;
            return Json(new { url = filePath });
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return BadRequest();
            var product = _productRepository.GetById(id);
            ViewData["Brands"] = new SelectList(_brandRepository.GetAll().ToList(), "Id", "BrandName",product.BrandId);

            ViewData["Categories"] = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName",product.CategoryId);
            if (product == null)
            {
                return NotFound();
            }

            return View("Edit", product);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    //delete image from wwwroot
                    if (model.Image != null)
                    {
                        //string wwwRootPath = _hostEnvironment.WebRootPath;
                        string path = "wwwroot/" + model.Image;
                        if(System.IO.File.Exists(path))
                            System.IO.File.Delete(path);

                    }                                          
                    string folder = $"UploadFiles/Images/Products/{DateTime.Now:yyyyMMdd}/";
                    model.Image = ImageUtils.UploadFileImage(model.ImageFile, folder);
                }

                _productRepository.Update(model);
                _notyf.Success("Success");
                return RedirectToAction("Index");
            }
            _notyf.Error("Failed Try again");
            return View("Edit");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", product);
        }

        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            if (id == 0)
                return BadRequest();
            var product = _productRepository.GetById(id);
            if (product == null)
            {

                return NotFound();
            }
            if (product.Image != null)
            {
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                string path = "wwwroot/" + product.Image;
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

            }

            _productRepository.Delete(product);
            _notyf.Success("Success");
            return RedirectToAction("Index");
        }
    }
}
