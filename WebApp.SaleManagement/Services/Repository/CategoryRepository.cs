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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(SaleDbContext saleDbContext) : base(saleDbContext)
        {
        }

        public IQueryable<Product> GetProductsByCategory(int categoryId)
        {
            return _saleDbContext.Products.Where(p => p.CategoryId == categoryId).AsQueryable();
        }
    }
}
