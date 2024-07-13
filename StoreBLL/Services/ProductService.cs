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

public class ProductService : ICrud
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public void Add(AbstractModel model)
    {
        var x = (ProductModel)model;
        var productEntity = new Product
        {
            TitleId = x.TitleId,
            ManufacturerId = x.ManufacturerId,
            UnitPrice = x.UnitPrice,
            Description = x.Description,
        };
        this.productRepository.Add(productEntity);
    }

    public void Delete(int modelId)
    {
        this.productRepository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var productEntities = this.productRepository.GetAll();
        return productEntities.Select(p => new ProductModel
        {
            TitleId = p.TitleId,
            ManufacturerId = p.ManufacturerId,
            UnitPrice = p.UnitPrice,
            Description = p.Description,
        });
    }

    public AbstractModel GetById(int id)
    {
        var productEntity = this.productRepository.GetById(id);
        if (productEntity == null)
        {
            return null;
        }

        return new ProductModel
        {
            TitleId = productEntity.TitleId,
            ManufacturerId = productEntity.ManufacturerId,
            UnitPrice = productEntity.UnitPrice,
            Description = productEntity.Description,
        };
    }

    public void Update(AbstractModel model)
    {
        var x = (ProductModel)model;
        var productEntity = this.productRepository.GetById(x.Id);
        if (productEntity != null)
        {
            productEntity.TitleId = x.TitleId;
            productEntity.ManufacturerId = x.ManufacturerId;
            productEntity.UnitPrice = x.UnitPrice;
            productEntity.Description = x.Description;

            this.productRepository.Update(productEntity);
        }
    }
}
