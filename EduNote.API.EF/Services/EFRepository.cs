using EduNote.API.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EduNote.API.EF.Services
{
    public class EFRepository<TContext> : EFReadOnlyRepository<TContext>, IRepository
        where TContext : DbContext
    {
        public EFRepository(TContext context)
            : base(context)
        {
        }

        public virtual TEntity Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = createdBy;

            context.Set<TEntity>().Add(entity);

            Save();

            return entity;
        }

        public virtual TEntity Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity
        {
            entity.Modified = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;

            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            Save();

            return entity;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : class, IEntity
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
