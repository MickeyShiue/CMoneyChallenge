using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CMoney.DataAccess.Lib.Interface;
using CMoney.DataAccess.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace CMoney.DataAccess.Lib.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CmoneyContext _context;
        private DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(CmoneyContext context)
        {
            this._context = context;
            this.DbSet = this._context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Create entity is null");
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Add(entity);
            }
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("CreateRange entities is null");
            }
            else
            {
                this.DbSet.AddRange(entities);
            }
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Update entity is null");
            }
            else
            {
                if (this._context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                this._context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Delete entity is null");
            }
            else
            {
                if (this._context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                this.DbSet.Remove(entity);
            }
        }

        public void DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            var delEntities = this.DbSet.Where(predicate);
            this.DbSet.RemoveRange(delEntities);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.AsNoTracking().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Find(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = this.DbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
    }
}
