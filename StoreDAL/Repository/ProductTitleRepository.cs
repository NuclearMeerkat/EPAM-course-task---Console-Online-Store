using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

namespace StoreDAL.Repository
{
    public class ProductTitleRepository : AbstractRepository, IProductTitleRepository
    {
        private readonly DbSet<ProductTitle> dbSet;

        public ProductTitleRepository(StoreDbContext context)
            : base(context)
        {
            this.dbSet = this.context.Set<ProductTitle>();
        }

        public void Add(ProductTitle entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(ProductTitle entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = dbSet.Find(id);
            if (user != null)
            {
                this.dbSet.Remove(user);
                this.context.SaveChanges();
            }
        }

        public IEnumerable<ProductTitle> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<ProductTitle> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
        }

        public ProductTitle GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(ProductTitle entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
