using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Services.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(SaleDbContext saleDbContext) : base(saleDbContext)
        {
        }

        public IQueryable<Product> GetProductsByBrand(int brandId)
        {
            return _saleDbContext.Products.Where(p => p.BrandId == brandId).AsQueryable();
        }
    }
}
