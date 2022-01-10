using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using WebApp.SaleManagement.ViewModels;

namespace WebApp.SaleManagement.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger,IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }
        // Chức năng search tại home
        public IActionResult Filter(string searchString)
        {
            
            if(searchString !=null && searchString.Trim() != "" )
            {
                if (searchString.Trim().ToLower().Contains("category"))
                    return RedirectToAction("Index", "Category");
                else if (searchString.Trim().ToLower().Contains("brand"))
                    return RedirectToAction("Index", "Brand");
                if (searchString.Trim().ToLower().Contains("product"))
                    return RedirectToAction("Index", "Product");
                else if (searchString.ToLower().Contains("customer"))
                    return RedirectToAction("Index", "Customer");
                
            }
            return RedirectToAction("Index");
            
        }
        public IActionResult Index()
        {
            var home = new HomeIndexViewModel
            {
                Employees = _homeRepository.CountEmployees(),
                Customers = _homeRepository.CountCustomer(),
                Orders = _homeRepository.CountOrders(),
                Revenue = _homeRepository.Revenue() / (decimal)1000000
            };
            return View(home);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        { 
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
