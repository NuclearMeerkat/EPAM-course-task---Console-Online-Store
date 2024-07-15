namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.FlowAnalysis;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

public class CustomerOrderService : ICrud
{
    private readonly ICustomerOrderRepository customerOrderRepository;

    public CustomerOrderService(StoreDbContext context)
    {
        this.customerOrderRepository = new CustomerOrderRepository(context);
    }
    public void Add(AbstractModel model)
    {
        var x = (CustomerOrderModel)model;
        var titleEntity = new CustomerOrder
        {
            Id = x.Id,
            UserId = x.UserId,
            OperationTime = DateTime.Now.ToString(),
            OrderStateId = x.OrderStateId,
        };
        this.customerOrderRepository.Add(titleEntity);
    }

    public void Delete(int modelId)
    {
        this.customerOrderRepository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var titleEntities = this.customerOrderRepository.GetAll();
        return titleEntities.Select(x => new CustomerOrderModel
        {
            Id = x.Id,
            UserId = x.UserId,
            OperationTime = x.OperationTime,
            OrderStateId = x.OrderStateId,
            State = x.State.StateName,
        });
    }

    public IEnumerable<AbstractModel> GetOrdersByCustomerId(int userId)
    {
        var titleEntities = this.customerOrderRepository.GetOrdersByCustomerId(userId);
        return titleEntities.Select(x => new CustomerOrderModel
        {
            Id = x.Id,
            UserId = x.UserId,
            OperationTime = x.OperationTime,
            OrderStateId = x.OrderStateId,
            State = x.State.StateName,
        });
    }

    public AbstractModel GetById(int id)
    {
        var res = this.customerOrderRepository.GetById(id);

        if (res == null)
        {
            return null;
        }

        return new CustomerOrderModel(res.Id, res.OperationTime, res.OrderStateId, res.UserId);
    }

    public void Update(AbstractModel model)
    {
        var x = (CustomerOrderModel)model;
        var orderEntity = this.customerOrderRepository.GetById(x.Id);
        if (orderEntity != null)
        {
            orderEntity.OrderStateId = x.OrderStateId;
            orderEntity.UserId = x.UserId;
            orderEntity.OperationTime= x.OperationTime;

            this.customerOrderRepository.Update(orderEntity);
        }
    }
}
