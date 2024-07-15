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
    public class CustomerOrderRepository : GenericRepository<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(StoreDbContext context)
             : base(context)
        {
        }

        public override IEnumerable<CustomerOrder> GetAll()
        {
            return this.dbSet
                .Include(o => o.State)
                .Include(o => o.User)
                .ToList();
        }

        public List<CustomerOrder> GetOrdersByCustomerId(int customerId)
        {
            var orders = this.dbSet
                .Include(o => o.State)
                .Include(o => o.User)
                .Where(o => o.UserId == customerId)
                .ToList();

            return orders;
        }
    }
}
