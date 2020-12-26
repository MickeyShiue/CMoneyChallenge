using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMoney.DataAccess.Lib.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
