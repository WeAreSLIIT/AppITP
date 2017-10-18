
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _entity;

        public Repository(DbContext Context)
        {
            this._context = Context;
            this._entity = this._context.Set<TEntity>();
        }

        //Get Methods
        public TEntity Get(long Id)
        {
            return this._entity.Find(Id);
        }

        public  IEnumerable<TEntity> GetAll()
        {
            return this._entity.ToList();
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> Predicate)
        {
            return this._entity.Where(Predicate).ToList();
        }

        //Add Methods
        public void Add(TEntity Entity)
        {
            this._entity.Add(Entity);
        }

        public void AddRange(IEnumerable<TEntity> Entities)
        {
            this._entity.AddRange(Entities);
        }

        //Remove Methods
        public void Remove(TEntity Entity)
        {
            this._entity.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<TEntity> Entities)
        {
            this._entity.RemoveRange(Entities);
        }
    }
}
