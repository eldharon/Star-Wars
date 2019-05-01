using Star_Wars.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<T> AddAsync(T t)
        {
            return await _repository.AddAsync(t);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindAsync(match);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindAllAsync(match);
        }

        public async Task DeleteAsync(T t)
        {
            await _repository.DeleteAsync(t);
        }

        public async Task<T> UpdateAsync(T updated, int key)
        {

            return await _repository.UpdateAsync(updated, key);
        }

        public IQueryable<T> GetIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            return _repository.GetIncludeAsync(includes);
        }
    }
}
