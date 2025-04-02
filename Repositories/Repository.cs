using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
            => _context.Set<T>().ToList();

        public T? GetById(int id)
            => _context.Set<T>().Find(id);

        public void Add(T entity)
            => _context.Set<T>().Add(entity);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

        public void Remove(T entity)
            => _context.Set<T>().Remove(entity);
    }
}
