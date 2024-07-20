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

public class ManufacturerService : ICrud
{
    private readonly IManufacturerRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryService"/> class with the specified context.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public ManufacturerService(StoreDbContext context)
    {
        this.repository = new ManufacturerRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (ManufacturerModel)model;
        this.repository.Add(new Manufacturer(0, x.Name));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var titleEntities = this.repository.GetAll();
        return titleEntities.Select(x => new ManufacturerModel(
            x.Id,
            x.Name));
    }

    public AbstractModel GetById(int id)
    {
        var manufacturerEntity = this.repository.GetById(id);
        if (manufacturerEntity == null)
        {
            return null;
        }

        return new ManufacturerModel(
            manufacturerEntity.Id,
            manufacturerEntity.Name);
    }

    public void Update(AbstractModel model)
    {
        var x = (ManufacturerModel)model;
        var userEntity = this.repository.GetById(x.Id);
        if (userEntity != null)
        {
            userEntity.Name = x.Name;

            this.repository.Update(userEntity);
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