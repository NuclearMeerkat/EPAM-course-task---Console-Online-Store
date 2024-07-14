namespace StoreDAL.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StoreDAL.Entities;

public interface ICustomerOrderRepository : IRepository<CustomerOrder>
{
    List<CustomerOrder> GetOrdersByCustomerId(int customerId);
}
