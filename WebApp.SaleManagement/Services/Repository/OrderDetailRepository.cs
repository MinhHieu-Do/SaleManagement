using Microsoft.EntityFrameworkCore;
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Services.Repository;

namespace WebApp.WebApp.Services.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SaleDbContext saleDbContext) : base(saleDbContext)
        {
        }

        public IQueryable<OrderDetail> GetOrderDetails(int OrderId)
        {
            return _saleDbContext.OrderDetails.Where(o => o.OrderId == OrderId).Include(x => x.Product).AsQueryable();
        }
    }
}
