using EduNote.API.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EduNote.API.EF.Services
{
    public class EFReadOnlyRepository<TContext> : IReadOnlyRepository  
        where TContext : DbContext
    {
        protected readonly TContext context;

        public EFReadOnlyRepository(TContext context)
        {
            this.context = context;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes.Any())
            {
                query = includes.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(query, (current, expression) => current.Include(expression));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(null, orderBy, skip, take, includes).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(null, orderBy, skip, take, includes).ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, orderBy, skip, take, includes).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, skip, take, includes).ToListAsync();
        }

        public virtual TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, null, null, null, includes).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, null, null, null, includes).SingleOrDefaultAsync();
        }

        public virtual TEntity GetFirst<TEntity>(
           Expression<Func<TEntity, bool>> filter = null,
           params Expression<Func<TEntity, object>>[] includes)
           where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, (items) => items.OrderBy(e => e.Id), null, null, includes).FirstOrDefault();
        }

        public virtual TEntity GetLast<TEntity>(
           Expression<Func<TEntity, bool>> filter = null,
           params Expression<Func<TEntity, object>>[] includes)
           where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, (items) => items.OrderByDescending(e => e.Id), null, null, includes).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, null, null, includes).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById<TEntity>(
            long id,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> set = context.Set<TEntity>();

            if (includes.Any())
            {
                set = includes.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(set, (current, expression) => current.Include(expression));
                return set.SingleOrDefault(e => e.Id == id);
            }

            return context.Set<TEntity>().Find(id);
        }

        public virtual Task<TEntity> GetByIdAsync<TEntity>(
            long id,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> set = context.Set<TEntity>();

            if (includes.Any())
            {
                set = includes.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(set, (current, expression) => current.Include(expression));
                return set.SingleOrDefaultAsync(e => e.Id == id);
            }

            return context.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).AnyAsync();
        }
    }
}
