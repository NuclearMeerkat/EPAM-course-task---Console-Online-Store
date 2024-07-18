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
            return this.dbSet
                .Include(p => p.Manufacturer)
                .Include(p => p.Title)
                .ThenInclude(t => t.Category)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}