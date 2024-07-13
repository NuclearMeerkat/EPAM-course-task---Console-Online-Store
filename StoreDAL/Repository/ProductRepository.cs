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
            this.dbSet = this.context.Set<Product>();
        }

        public void Add(Product entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
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
            return this.dbSet
                .Include(p => p.Title)
                .Include(p => p.Manufacturer)
                .ToList();
        }

        public IEnumerable<Product> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                .Include(p => p.Title)
                .Include(p => p.Manufacturer)
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
        }

        public Product GetById(int id)
        {
            return this.dbSet
                .Include(p => p.Title)
                .Include(p => p.Manufacturer)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}