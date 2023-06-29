using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Repositories
{
    public interface IRepository<T>where T : class, new() //means it T type must be a class, not an abstract
    {
        IQueryable<T> GetAll(Expression<Func<T,bool>> expression=null);
        T GetFirst(Expression<Func<T,bool>> expression=null);
        T Add(T entity);
        T Edit(T entity, EntityEntry<T> rules=null);
        void Remove(T entity);
        int Save();
    }
}
