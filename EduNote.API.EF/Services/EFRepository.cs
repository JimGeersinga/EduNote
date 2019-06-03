using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual TEntity Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            context.Set<TEntity>().Add(entity);

            Save();

            return entity;
        }

        public virtual TEntity Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
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
                AddInfo();
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
                AddInfo();
                return context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private void AddInfo()
        {
            IEnumerable<EntityEntry> entries = context.ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseModel)entry.Entity).Created = DateTime.Now;
                }
                ((BaseModel)entry.Entity).Modified = DateTime.Now;
            }
        }
    }
}
