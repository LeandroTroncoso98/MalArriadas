using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data.Repository
{
    public interface IRepository<C> where C : class
    {
        C Get(int id);

        IEnumerable<C> GetAll(Expression<Func<C, bool>> filter = null, Func<IQueryable<C>, IOrderedQueryable<C>> orderBy = null, string includeProperties = null);
        C GetFirstOrDefault(Expression<Func<C, bool>> filter = null,
            string includeProperties = null);
        void Add(C entity);
        void Remove(int id);
        void Remove(C entity);
    }
}
