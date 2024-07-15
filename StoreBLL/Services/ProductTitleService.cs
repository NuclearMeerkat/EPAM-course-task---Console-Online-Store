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

public class ProductTitleService : ICrud
{
    private readonly IProductTitleRepository productTitleRepository;

    public ProductTitleService(StoreDbContext context)
    {
        this.productTitleRepository = new ProductTitleRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (ProductTitleModel)model;

        var titleEntity = new ProductTitle
        {
            Id = x.Id,
            Title = x.Title,
            CategoryId = x.CategoryId,
        };
        this.productTitleRepository.Add(titleEntity);
    }

    public void Delete(int modelId)
    {
        this.productTitleRepository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var titleEntities = this.productTitleRepository.GetAll();
        return titleEntities.Select(x => new ProductTitleModel(
            x.Id,
            x.Title,
            x.CategoryId,
            new CategoryModel(x.CategoryId, x.Category.Name)));
    }

    public AbstractModel GetById(int id)
    {
        var titleEntity = this.productTitleRepository.GetById(id);
        if (titleEntity == null)
        {
            return null;
        }

        return new ProductTitleModel(
            titleEntity.Id,
            titleEntity.Title,
            titleEntity.CategoryId,
            new CategoryModel(titleEntity.CategoryId, titleEntity.Category.Name));
    }

    public void Update(AbstractModel model)
    {
        var x = (ProductTitleModel)model;
        var titleEntity = this.productTitleRepository.GetById(x.Id);
        if (titleEntity != null)
        {
            titleEntity.Id = x.Id;
            titleEntity.Title = x.Title;
            titleEntity.CategoryId = x.CategoryId;

            this.productTitleRepository.Update(titleEntity);
        }
    }
}
