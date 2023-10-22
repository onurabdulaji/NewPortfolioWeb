using DAL.Concrete;
using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public string Add(T t)
        {
            _context.Set<T>().Add(t);
            return _context.SaveChanges().ToString();
        }

        public async Task<T> CreateAsync(T t)
        {
            await _context.AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAllWithFilter(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
