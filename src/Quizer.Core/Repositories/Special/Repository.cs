using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Repositories.Special
{

    //class will work both for question and answer classes
    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext db;
        private readonly DbSet<T> table;

        public Repository(DbContext db, DbSet<T> table)
        {
            this.db = db;
            this.table = db.Set<T>();
        }

        //protected means these will be visible to only those who inherited this class
        protected DbContext Db { get=>this.db;  }
        protected DbSet<T> Table { get=>this.table; }
        public T Add(T entity)
        {
            table.Add(entity);
            return entity;
        }

        public T Edit(T entity, EntityEntry<T> rules = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var query = this.table.AsQueryable();
            if(expression != null) query= query.Where(expression);
            return query;
        }

        public T GetFirst(Expression<Func<T, bool>> expression = null)
        {
            var query = this.table.AsQueryable();
            if (expression != null) query = query.Where(expression);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            this.table.Remove(entity);
        }

        public int Save()
        {
            return this.db.SaveChanges();
        }
    }
}
