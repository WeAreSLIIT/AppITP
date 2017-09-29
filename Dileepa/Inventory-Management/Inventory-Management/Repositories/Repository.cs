using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Inventory_Management.IRepositories;

namespace Inventory_Management.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
	{
		protected readonly DbContext Context;

		public Repository(DbContext context)
		{
			Context=context;
		}

		public TEntity Get(long Id)
		{
			return Context.Set<TEntity>().Find(Id);
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().ToList();
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> Predicate)
		{
			return Context.Set<TEntity>().Where(Predicate);
			throw new NotImplementedException();
		}

		public void Add(TEntity Entity)
		{
			Context.Set<TEntity>().Add(Entity);
			throw new NotImplementedException();
		}

		public void AddRange(IEnumerable<TEntity> Entities)
		{
			Context.Set<TEntity>().AddRange(Entities);
			throw new NotImplementedException();
		}

		public void Remove(TEntity Entity)
		{
			Context.Set<TEntity>().Remove(Entity);
			throw new NotImplementedException();
		}

		public void RemoveRange(IEnumerable<TEntity> Entities)
		{
			Context.Set<TEntity>().RemoveRange(Entities);
			throw new NotImplementedException();
		}
	}
}