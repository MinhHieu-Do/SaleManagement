
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using System.Linq;
using WebApp.SaleManagement.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApp.SaleManagement.Services.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SaleDbContext saleDbContext) : base(saleDbContext)
        {
        }

        public IQueryable<Order> GetOrderByCustomer(int customerId)
        {
            return _saleDbContext.Orders.Where(p => p.Id == customerId).AsQueryable();
        }

        public IQueryable<Customer> NewCustomers()
        {
            return _saleDbContext.Customers.Include(x => x.Orders).Where(a=>a.Orders.Count==0);
        }
    }
}
