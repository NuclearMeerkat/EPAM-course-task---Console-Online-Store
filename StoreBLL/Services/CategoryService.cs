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

public class CategoryService : ICrud
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryService(StoreDbContext context)
    {
        this.categoryRepository = new CategoryRepository(context);
    }

    public void Add(AbstractModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int modelId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var titleEntities = this.categoryRepository.GetAll();
        return titleEntities.Select(x => new CategoryModel(
            x.Id,
            x.Name));
    }

    public AbstractModel GetById(int id)
    {
        var userEntity = this.categoryRepository.GetById(id);
        if (userEntity == null)
        {
            return null;
        }

        return new CategoryModel(
            userEntity.Id,
            userEntity.Name);
    }

    public void Update(AbstractModel model)
    {
        throw new NotImplementedException();
    }
}
