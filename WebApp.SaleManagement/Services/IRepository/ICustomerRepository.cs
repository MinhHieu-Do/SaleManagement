using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.Services.IRepository
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IQueryable<Order> GetOrderByCustomer(int customerId);
        IQueryable<Customer> NewCustomers();
    }
}
