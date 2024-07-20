namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

public class OrderDetailService : ICrud
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class with the specified context.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    private readonly IOrderDetailRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class with the specified context.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public OrderDetailService(StoreDbContext context)
    {
        this.repository = new OrderDetailRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (OrderDetailModel)model;
        var orderDetailEntity = new OrderDetail
        {
            ProductId = x.ProductId,
            Price = x.Price,
            OrderId = x.CustomerOrderId,
            ProductAmount = x.Amount,
        };
        this.repository.Add(orderDetailEntity);
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var orderDetailEntities = this.repository.GetAll();
        return orderDetailEntities.Select(p => new OrderDetailModel(
            p.Id,
            p.ProductId,
            p.Price,
            p.ProductAmount,
            p.OrderId));
    }

    public AbstractModel GetById(int id)
    {
        var orderDetailEntity = this.repository.GetById(id);
        if (orderDetailEntity == null)
        {
            return null;
        }

        return new OrderDetailModel(
            orderDetailEntity.Id,
            orderDetailEntity.ProductId,
            orderDetailEntity.Price,
            orderDetailEntity.ProductAmount,
            orderDetailEntity.OrderId);
    }

    public void Update(AbstractModel model)
    {
        var x = (OrderDetailModel)model;
        var productEntity = this.repository.GetById(x.Id);
        if (productEntity != null)
        {
            productEntity.Id = x.Id;
            productEntity.ProductId = x.ProductId;
            productEntity.Price = x.Price;
            productEntity.OrderId = x.CustomerOrderId;
            productEntity.ProductAmount = x.Amount;
            productEntity.OrderId = x.CustomerOrderId;

            this.repository.Update(productEntity);
        }
    }

    /// <summary>
    /// Return count of the enteties in the specyfic DbSet.
    /// </summary>
    public int Count()
    {
        return this.repository.Count();
    }
}