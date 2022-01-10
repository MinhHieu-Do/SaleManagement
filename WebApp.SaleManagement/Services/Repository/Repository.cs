using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Services.IRepository;

namespace WebApp.SaleManagement.Services.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly SaleDbContext _saleDbContext;
        public Repository(SaleDbContext saleDbContext)
        {
            _saleDbContext = saleDbContext;
        }

        //Save change
        private async Task SaveChangeAsync() => await _saleDbContext.SaveChangesAsync();
        private void SaveChange() => _saleDbContext.SaveChanges();

        public IQueryable<T> GetAll()
        {
            return _saleDbContext.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetByFiler(Func<T, bool> predicate)
        {
            return _saleDbContext.Set<T>().Where(predicate).AsQueryable();
        }

        public T GetById(int id)
        {
            return _saleDbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _saleDbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _saleDbContext.AddAsync(entity);
            await SaveChangeAsync();
        }

        public void Add(T entity)
        {
            _saleDbContext.Add(entity);
            SaveChange();
        }

        public async Task UpdateAsync(T entity)
        {
           _saleDbContext.Entry(entity).State = EntityState.Modified;
           await SaveChangeAsync();
        }

        public void Update(T entity)
        {
            _saleDbContext.Entry(entity).State = EntityState.Modified;
            SaveChange();
        }

        public async Task DeleteAsync(T entity)
        {
            _saleDbContext.Remove(entity);
            await SaveChangeAsync();
        }

        public void Delete(T entity)
        {
            _saleDbContext.Remove(entity);
            SaveChange();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _saleDbContext.Set<T>().Where(predicate).Count();
        }
    }
}
