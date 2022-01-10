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
    public class OrderManagerController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _detailOrderRepository;
        private readonly IProductRepository _productRepository;
        public OrderManagerController(ICustomerRepository customerRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository
            , IProductRepository productRepository, INotyfService notyfService)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _detailOrderRepository = orderDetailRepository;
            _productRepository = productRepository;
            _notyf = notyfService;
        }
        public IActionResult Index()
        {
            var orders = _orderRepository.GetOrderIndex();



            int review = 0, shipment = 0, complete = 0;

            ViewBag.CountAll = orders.ToList().Count();
            foreach (var order in orders)
            {
                if (order.Status.ToString() == "PendingReview")
                    review += 1;
                else if (order.Status.ToString() == "PendingShipment")
                {
                    shipment += 1;
                }
                else
                    complete += 1;
                ViewBag.Shipment = shipment;
                ViewBag.Review = review;
                ViewBag.Complete = complete;

            }
            
            return View(orders);
        }
        public IActionResult OrderByStatus(string status)
        {
            var orders = _orderRepository.GetOrderIndex();
            if (!string.IsNullOrEmpty(status))
            {
                orders = orders.Where(c => c.Status.ToString() == status).ToList();

            }
           
            return PartialView("_ListOrder",orders);
        }

        public IActionResult Filter(string searchString)
        {
            ViewData["currentFilter"] = searchString;
            var orders = _orderRepository.GetOrderIndex();

            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(c => c.Id.ToString().Contains(searchString.ToLower()));
            }
            
            return PartialView("_ListOrder", orders);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
                return BadRequest();
            var orderDetails = _detailOrderRepository.GetOrderDetails(id);
            var order = _orderRepository.GetById(id);
            var customer = _customerRepository.GetById(order.CustomerId);
            
           
            var model = new OrderDetailViewModel
            {
                Customer = customer,
                Order = order,
                OrderDetails = orderDetails
            };

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return BadRequest();
            
            var order = _orderRepository.GetById(id);
            if (order == null)
                return NotFound();

            return PartialView("_Edit",order);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var order = _orderRepository.GetById(id);
            if (order == null)
                return NotFound();

            return PartialView("_Delete", order);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Order model)
        { 
            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateAsync(model);
                _notyf.Success("Update Status success");
                return RedirectToAction("Index");
                
            }
            _notyf.Error("Error Try again");
            return View("Index");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null && id == 0)
            {

                return NotFound();
            }

            await _orderRepository.DeleteAsync(order);
            _notyf.Success("Sucess");
            return RedirectToAction("Index");
        }


    }
}
