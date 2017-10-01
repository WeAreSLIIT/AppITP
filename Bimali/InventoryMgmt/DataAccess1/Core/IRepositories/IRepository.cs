using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.IRepositories
{

        public interface IRepository<TEntity> where TEntity : class
        {
        //TEntity Get(string PublicId);
            TEntity Get(int Id);
            IEnumerable<TEntity> GetAll();
            IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> Predicate);

            void Add(TEntity Entity);
            void AddRange(IEnumerable<TEntity> Entities);

            void Remove(TEntity Entity);
            void RemoveRange(IEnumerable<TEntity> Entities);
        }
}
