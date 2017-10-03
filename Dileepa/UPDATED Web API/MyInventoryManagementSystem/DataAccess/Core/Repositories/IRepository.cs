using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
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
