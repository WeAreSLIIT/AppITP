using DataAccess.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity Entity)
        {
            Context.Set<TEntity>().Add(Entity);
        }

        public void AddRange(IEnumerable<TEntity> Entities)
        {
            Context.Set<TEntity>().AddRange(Entities);
        }

        //public TEntity Get(long Id)
        //{
        //    return Context.Set<TEntity>().Find(Id);
        //}

        //public TEntity Get(string Id)
        //{
        //    return Context.Set<TEntity>().Find(Id);
        //}
        public TEntity Get(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity Entity)
        {
            Context.Set<TEntity>().Remove(Entity);
        }
     

        public void RemoveRange(IEnumerable<TEntity> Entities)
        {
            Context.Set<TEntity>().RemoveRange(Entities);
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> Predicate)
        {
            return Context.Set<TEntity>().Where(Predicate);
        }
    }
}
