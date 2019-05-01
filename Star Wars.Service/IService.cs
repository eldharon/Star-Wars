using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Star_Wars.Service
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T t);
        Task DeleteAsync(T t);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        IQueryable<T> GetIncludeAsync(params Expression<Func<T, object>>[] includes);
        Task<T> UpdateAsync(T updated, int key);
    }
}