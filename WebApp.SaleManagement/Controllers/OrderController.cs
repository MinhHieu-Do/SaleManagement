using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Helpers;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using WebApp.SaleManagement.ViewModels;

namespace WebApp.SaleManagement.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _detailOrderRepository;
        private readonly IProductRepository _productRepository;
        public OrderController(ICustomerRepository customerRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository
            , IProductRepository productRepository,INotyfService notyf)
        {
            _notyf = notyf;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _detailOrderRepository = orderDetailRepository;
            _productRepository = productRepository;
        }
        
        public IActionResult Create(int id = 0)
        {
            if (id != 0)
            {
                HttpContext.Session.Set("CustomerId", id);
            }
            var products = _productRepository.GetProductIndex().ToList();
            var cartModel = new CartViewModel
            {
                Products = products,
                CartItems = HttpContext.Session.Get<List<CartItem>>("GioHang")
            };
            return View(cartModel);
        }
        [HttpPost]
        public IActionResult Filter(string searchString)
        {
            var products = _productRepository.GetProductIndex();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(c => c.ProductName.ToLower().Contains(searchString.ToLower()) ||
                                            c.Brand.BrandName.ToLower().Contains(searchString.ToLower()) ||
                                            c.Category.CategoryName.ToLower().Contains(searchString.ToLower()));
            }
            return PartialView("_FindProduct", products);
        }
        private List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }
        public IActionResult AddToCart(int id, int quantity)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);

            if (item == null)//chưa có
            {
                var product = _productRepository.GetById(id);
                if (product != null)
                {
                    item = new CartItem
                    {
                        ProductId = id,
                        ProductName = product.ProductName,
                        ProductPrice = product.Price,
                        ProductImage = product.Image,
                        ProductQuantity = quantity
                    };
                    myCart.Add(item);
                }
            }
            else
            {
                item.ProductQuantity += quantity;
            }
            HttpContext.Session.Set("GioHang", myCart);
            
            _notyf.Success("Add Success");

            return PartialView("_ListCart", myCart);
        }
        [HttpPost]
        public IActionResult UpdateCart(int id, int quantity)
        {
            var myCart = Carts;
            IEnumerable<CartItem> cc = Carts;

            var item = myCart.SingleOrDefault(p => p.ProductId == id);
            if (quantity == 0)
                DeleteCart(id);
            if (item == null)//chưa có
            {
                var product = _productRepository.GetById(id);
                if (product != null)
                {
                    item = new CartItem
                    {
                        ProductId = id,
                        ProductName = product.ProductName,
                        ProductPrice = product.Price,
                        ProductImage = product.Image,
                        ProductQuantity = quantity,
                        
                      
                    };
                    myCart.Add(item);
                }
            }
            else
            {
                item.ProductQuantity = quantity;
            }

            HttpContext.Session.Set("GioHang", myCart);
            _notyf.Success("Update cart Success");
            return PartialView("_LineCart", item);
        }
        [HttpPost]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var myCart = Carts;
            int index = isExist(id);
            if (index >= 0)
                myCart.RemoveAt(index);
            HttpContext.Session.Set("GioHang", myCart);
            _notyf.Success("Success");
            return RedirectToAction("Create");
        }


        public async Task<IActionResult> SaveOrder(string userName = "")
        {
            var customerId = HttpContext.Session.Get<int>("CustomerId");
            if (customerId == 0)
                return RedirectToAction("Index", "Customer");
            decimal total = 0;
            foreach (var item in Carts)
            {
                total += item.Total;
            }
            var order = new Order
            {
                CustomerId = HttpContext.Session.Get<int>("CustomerId"),
                AdminName = userName,
                OrderDate = DateTime.Now.ToLocalTime(),
                Status = Status.PendingReview,
                Total = total
            };
            await _orderRepository.AddAsync(order);
            foreach (var item in Carts)
            {
                var detailOrder = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                    Quantity = item.ProductQuantity
                };
                var product = _productRepository.GetById(item.ProductId);

                if (product.Quantity - detailOrder.Quantity >= 0)
                {
                    await _detailOrderRepository.AddAsync(detailOrder);
                    product.Quantity -= detailOrder.Quantity;
                    await _productRepository.UpdateAsync(product);
                }


            }

            var od = _detailOrderRepository.GetByFiler(o => o.OrderId == order.Id);
            if (od.Count() == 0)
            {
                //await _orderRepository.DeleteAsync(order);
                order.Total = 0;
                await _orderRepository.UpdateAsync(order);

            }

            List<CartItem> listNull = null;
            HttpContext.Session.Set("GioHang", listNull);
            HttpContext.Session.Clear();
            _notyf.Success("Order Success");
            return RedirectToAction("Details", "Customer", new { Id = order.CustomerId });
        }

        private int isExist(int id)
        {
            List<CartItem> cart = Carts;
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
