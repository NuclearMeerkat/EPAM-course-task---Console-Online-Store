namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

public class OrderStateRepository : GenericRepository<OrderState>, IOrderStateRepository
{
    public OrderStateRepository(StoreDbContext context)
             : base(context)
    {
    }
}