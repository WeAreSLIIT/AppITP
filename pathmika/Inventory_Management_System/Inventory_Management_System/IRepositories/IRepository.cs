using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Inventory_Management_System.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> Predicate);

        void Add(TEntity Entity);
        void AddRange(IEnumerable<TEntity> Entities);

        void Remove(TEntity Entity);
        void RemoveRange(IEnumerable<TEntity> Entities);
    }
}