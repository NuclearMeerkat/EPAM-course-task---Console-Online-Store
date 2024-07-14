using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

namespace StoreDAL.Repository
{
    public abstract class GenericRepository<T> : AbstractRepository, IRepository<T>
        where T : BaseEntity
    {
        protected readonly DbSet<T> dbSet;

        protected GenericRepository(StoreDbContext context)
            : base(context)
        {
            this.dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public virtual void DeleteById(int id)
        {
            var entity = this.dbSet.Find(id);
            if (entity != null)
            {
                this.dbSet.Remove(entity);
                this.context.SaveChanges();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public virtual IEnumerable<T> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
        }

        public virtual T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
