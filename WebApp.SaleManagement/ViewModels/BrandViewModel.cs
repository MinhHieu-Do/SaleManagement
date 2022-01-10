using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.ViewModels
{
    public class BrandViewModel
    {
        public Brand Brand { get; set; }
        public IQueryable<Product> Products { get; set; }
    }
}
