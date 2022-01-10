using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Services.IRepository
{
    public interface IHomeRepository
    {
        int CountEmployees();
        int CountCustomer();
        int CountOrders();
        decimal Revenue();
    }
}
