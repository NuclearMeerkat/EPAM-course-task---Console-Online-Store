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
    public class ProductTitleRepository : GenericRepository<ProductTitle>, IProductTitleRepository
    {
        public ProductTitleRepository(StoreDbContext context)
            : base(context)
        {
        }

        public override IEnumerable<ProductTitle> GetAll()
        {
            return this.dbSet
                .Include(pt => pt.Category)
                .ToList();
        }
    }
}
