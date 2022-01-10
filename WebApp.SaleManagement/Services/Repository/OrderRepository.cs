using Microsoft.EntityFrameworkCore;
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Services.Repository;

namespace WebApp.SaleManagement.Services.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(SaleDbContext saleDbContext) : base(saleDbContext)
        {
        }

        public IEnumerable<Order> GetOrderIndex()
        {
            return _saleDbContext.Orders.Include(p => p.Customer);
        }
    }
}
