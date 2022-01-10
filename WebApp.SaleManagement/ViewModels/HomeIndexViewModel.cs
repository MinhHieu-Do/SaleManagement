using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.ViewModels
{
    public class HomeIndexViewModel
    {
        public int Employees { get; set; }
        public int Customers { get; set; }
        public int Orders { get; set; }
        public decimal Revenue { get; set; }
        public IEnumerable<Customer> ListCustomers { get; set; }
    }
}
