using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Services.IRepository
{
    public interface IRepository<T> where T:class
    {
        //Get All
        IQueryable<T> GetAll();
        
        //Get By Filter
        IQueryable<T> GetByFiler(Func<T, bool> predicate);
        
        //Get by Id
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        //Add
        Task AddAsync(T entity);
        void Add(T entity);

        //Update
        Task UpdateAsync(T entity);
        void Update(T entity);

        //Delete
        Task DeleteAsync(T entity);
        void Delete(T entity);

        //Count
        int Count(Func<T, bool> predicate);
        
    }
}
