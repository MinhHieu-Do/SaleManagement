using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Services.IRepository;
using WebApp.SaleManagement.ViewModels;

namespace WebApp.SaleManagement.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly ICustomerRepository _customerRepository;
        public AdminController(IHomeRepository homeRepository,IOrderRepository orderRepository,ICustomerRepository customerRepository)
        {
            _homeRepository = homeRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            
            var home = new HomeIndexViewModel
            {
                Employees = _homeRepository.CountEmployees(),
                Customers = _homeRepository.CountCustomer(),
                Orders = _homeRepository.CountOrders(),
                Revenue = _homeRepository.Revenue() / (decimal)1000000,
                ListCustomers=_customerRepository.NewCustomers()
            };
            return View(home);
        }
        public IActionResult OrderRevenue()
        {
            var orders = _orderRepository.GetAll().AsEnumerable();
            var rs = orders.Where(a=>((DateTime.Now.Date)-(a.OrderDate.Date)).Days<=7)
                    .OrderByDescending(o=>o.OrderDate.ToString("dd/MM/yyyy"))
                    .GroupBy(x => x.OrderDate.ToString("dd/MM/yyyy"))
                    .Select(y => new
                    {
                        ngay = y.Key.ToString(),
                        SoLuong = y.Count(),
                        TongTien = (y.Sum(p => p.Total) / 1000000)

                    });

            return Ok(rs);
        }
    }
}
