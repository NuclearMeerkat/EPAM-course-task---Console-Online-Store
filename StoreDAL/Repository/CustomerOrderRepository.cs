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
            return dbSet
                .Include(o => o.State)
                .Include(o => o.User)
                .ToList();
        }

        public List<CustomerOrder> GetOrdersByCustomerId(int customerId)
        {
            var orders = dbSet
                .Include(o => o.State)
                .Include(o => o.User)
                .Where(o => o.UserId == customerId)
                .ToList();

            return orders;
        }

        //public void CancelOrder(int orderId)
        //{
        //    var order = dbSet.Find(orderId);
        //    if (order != null)
        //    {
        //        order.OrderStateId = 8; // Now it always confirmed by client TODO
        //        context.SaveChanges();
        //    }
        //}

        //public void ConfirmOrderDelivery(int orderId)
        //{
        //    var order = dbSet.Find(orderId);
        //    if (order != null)
        //    {
        //        order.OrderStateId = // Set to delivered state ID
        //        context.SaveChanges();
        //    }
        //}
    }
}
