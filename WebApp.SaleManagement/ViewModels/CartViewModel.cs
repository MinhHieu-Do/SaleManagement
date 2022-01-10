using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.ViewModels
{
    public class CartViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
