using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;

namespace WebApp.SaleManagement.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        public CustomerController(ICustomerRepository customerRepository,IOrderRepository orderRepository,INotyfService notyf)
        {
            _notyf = notyf;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Customer model)
        {
            model.JoinDate = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                await _customerRepository.AddAsync(model);
                _notyf.Success("Seccess");
                return RedirectToAction("Index");
                
            }
            _notyf.Error("Failed Try Again");
            return View("Create");
        }

        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }


            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Orders = _orderRepository.GetByFiler(o => o.CustomerId == customer.Id).ToList();
            

            return View("Details",customer);

        }

        public IActionResult Filter(string searchString)
        {
            ViewData["currentFilter"] = searchString;
            var customers = _customerRepository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(searchString.ToLower()));
            }

            return PartialView("_ListCustomer", customers);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return BadRequest();
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View("Edit", customer);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Customer model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.UpdateAsync(model);
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
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", customer);
        }

        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (id == 0)
                return BadRequest();
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {

                return NotFound();
            }

            await _customerRepository.DeleteAsync(customer);
            _notyf.Success("Success");
            return RedirectToAction("Index");
        }
    }
}
