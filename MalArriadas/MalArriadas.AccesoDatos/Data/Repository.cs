using MalArriadas.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data
{
    public class Repository<C> : IRepository<C> where C : class
    {
        private readonly DbContext _context;
        internal DbSet<C> dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<C>();
        }
        public void Add(C entity)
        {
            dbSet.Add(entity);
        }
        public C Get(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<C> GetAll(Expression<Func<C, bool>> filter = null, Func<IQueryable<C>, IOrderedQueryable<C>> orderBy = null, string includeProperties = null)
        {
            IQueryable<C> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }
        public C GetFirstOrDefault(Expression<Func<C, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<C> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }
        public void Remove(int id)
        {
            C entity = dbSet.Find(id);    
            Remove(entity);
        }
        public void Remove(C entity)
        {
            dbSet.Remove(entity);
        }

       
    }
}
