using Star_Wars.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {

        //tworzy obiekt contextu odpowiedzialnego za łączność z bazą
        private readonly StarWarsContext _db = new StarWarsContext();

        //zwraca całą kolekcję w postaci listy
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQuery()
        {
            IQueryable<T> query = _db.Set<T>();
            return query;
        }
        public async Task<T> GetAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        //zwraca kolekcję obiektów wraz z obiektami klasy rodzic
        public IQueryable<T> GetIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            var t = GetQuery();
            return includes.Aggregate(t, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T> AddAsync(T t)
        {
            var result = _db.Set<T>().Add(t);
            await _db.SaveChangesAsync();

            return result;
        }


        //znajduje wskazany rekord na podstawie lambda expression
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _db.Set<T>().SingleOrDefaultAsync(match);
        }

        //znajduje wskazaną kolekcję rekordów na podstawie lambda expression
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _db.Set<T>().Where(match).ToListAsync();
        }

        public async Task DeleteAsync(T t)
        {
            _db.Set<T>().Remove(t);
            await _db.SaveChangesAsync();
        }
        //aktualizuje wybrany rekord
        public async Task<T> UpdateAsync(T updated, int key)
        {
            if (updated == null)
                throw new ArgumentNullException(nameof(updated));
            //sprawdzenie czy podany obiekt na pewno istnieje w bazie
            T existing = await _db.Set<T>().FindAsync(key);
            if (existing != null)
            {
                _db.Entry(existing).CurrentValues.SetValues(updated);
                await _db.SaveChangesAsync();
            }
            return existing;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
