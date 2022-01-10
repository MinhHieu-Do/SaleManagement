using Microsoft.EntityFrameworkCore;
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Services.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SaleDbContext saleDbContext) : base(saleDbContext)
        {
        }

        public IQueryable<Product> GetProductIndex()
        {
            return _saleDbContext.Products.Include(p => p.Category).Include(p => p.Brand).AsQueryable();
        }

        
    }
}
