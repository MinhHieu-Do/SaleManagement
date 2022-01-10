﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.Services.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IQueryable<OrderDetail> GetOrderDetails(int OrderId);

    }
}
