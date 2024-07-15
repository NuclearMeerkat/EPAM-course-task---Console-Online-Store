namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

public class OrderStateService : ICrud
{
    private readonly IOrderStateRepository repository;

    public OrderStateService(StoreDbContext context)
    {
        this.repository = new OrderStateRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (OrderStateModel)model;
        this.repository.Add(new OrderState(x.Id, x.StateName));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var orderStateEntities = this.repository.GetAll();
        return orderStateEntities.Select(p => new OrderStateModel(
            p.Id,
            p.StateName));
    }

    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new OrderStateModel(res.Id, res.StateName);
    }

    public void Update(AbstractModel model)
    {
        var x = (OrderStateModel)model;
        var userEntity = this.repository.GetById(x.Id);
        if (userEntity != null)
        {
            userEntity.Id = x.Id;
            userEntity.StateName = x.StateName;

            this.repository.Update(userEntity);
        }
    }
}