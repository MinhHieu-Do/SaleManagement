using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Services.IRepository;

namespace WebApp.SaleManagement.Services.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly SaleDbContext _saleDbContext;
        public HomeRepository(SaleDbContext saleDbContext)
        {
            _saleDbContext = saleDbContext;
        }
        public int CountCustomer()
        {
            return _saleDbContext.Customers.Count();
        }

        public int CountEmployees()
        {
            return _saleDbContext.Users.Count();
        }

        public int CountOrders()
        {
            return _saleDbContext.Orders.Count();
        }

        public decimal Revenue()
        {
            var orders = _saleDbContext.Orders.ToList();
            decimal total = 0;
            foreach (var order in orders)
            {
                total += order.Total;
            }
            return total;
        }
    }
}
