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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreDbContext context)
             : base(context)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            return this.dbSet
                .Include(p => p.Manufacturer)
                .Include(p => p.Title)
                .ThenInclude(t => t.Category)
                .ToList();
        }

        public override Product GetById(int id)
        {
            var product = this.dbSet
                .Include(p => p.Manufacturer)
                .Include(p => p.Title)
                .ThenInclude(t => t.Category)
                .FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} was not found.");
            }

            // Perform additional null checks
            product.Manufacturer ??= new Manufacturer(); // Ensure Manufacturer is not null
            product.Title ??= new ProductTitle(); // Ensure Title is not null
            product.Title.Category ??= new Category(); // Ensure Category is not null

            return product;
        }
    }
}