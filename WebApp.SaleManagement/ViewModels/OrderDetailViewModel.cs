using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.ViewModels
{
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
