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
    public class ProductRepository : AbstractRepository, IProductRepository
    {
        private readonly DbSet<Product> dbSet;

        public ProductRepository(StoreDbContext context)
            : base(context)
        {
            this.dbSet = context.Set<Product>();
        }

        public void Add(Product entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            context.Products.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = this.dbSet.Find(id);
            if (entity != null)
            {
                this.dbSet.Remove(entity);
                this.context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<Product> GetAll(int pageNumber, int rowCount)
        {
            return context.Products
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
        }

        public Product GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(Product entity)
        {
            var existingProduct = context.Products.Find(entity.Id);
            if (existingProduct != null)
            {
                existingProduct.TitleId = entity.TitleId;
                existingProduct.ManufacturerId = entity.ManufacturerId;
                existingProduct.Description = entity.Description;

                context.Products.Update(existingProduct);
                context.SaveChanges();
            }
        }
    }
}