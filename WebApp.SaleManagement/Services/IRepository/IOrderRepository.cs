using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.Services.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrderIndex();
    }
}
