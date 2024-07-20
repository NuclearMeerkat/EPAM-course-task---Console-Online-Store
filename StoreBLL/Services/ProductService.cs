namespace StoreBLL.Services
{
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

    /// <summary>
    /// Provides services related to products, including CRUD operations.
    /// </summary>
    public class ProductService : ICrud
    {
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public ProductService(StoreDbContext context)
        {
            this.productRepository = new ProductRepository(context);
        }

        /// <summary>
        /// Adds a new product to the repository.
        /// </summary>
        /// <param name="model">The product model to add.</param>
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

        /// <summary>
        /// Deletes a product from the repository by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the product to delete.</param>
        public void Delete(int modelId)
        {
            this.productRepository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all products from the repository.
        /// </summary>
        /// <returns>A collection of product models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var productEntities = this.productRepository.GetAll();
            return productEntities.Select(p => new ProductModel
            (
                p.Id,
                p.TitleId,
                p.ManufacturerId,
                p.UnitPrice,
                p.Description,
                new ProductTitleModel(p.Title.Id, p.Title.Title, p.Title.CategoryId, new CategoryModel(p.Title.Category.Id, p.Title.Category.Name)),
                new ManufacturerModel(p.Manufacturer.Id, p.Manufacturer.Name)));
        }

        /// <summary>
        /// Retrieves all products from the repository.
        /// </summary>
        /// <returns>A collection of product models.</returns>
        public IEnumerable<AbstractModel> GetAllByTitle(int titleId)
        {
            var productEntities = this.productRepository.GetAll();
            return productEntities.Select(p => new ProductModel
            (
                p.Id,
                p.TitleId,
                p.ManufacturerId,
                p.UnitPrice,
                p.Description,
                new ProductTitleModel(p.Title.Id, p.Title.Title, p.Title.CategoryId, new CategoryModel(p.Title.Category.Id, p.Title.Category.Name)),
                new ManufacturerModel(p.Manufacturer.Id, p.Manufacturer.Name)))
                .Where(p => p.TitleId == titleId);
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product model if found; otherwise, <c>null</c>.</returns>
        public AbstractModel GetById(int id)
        {
            var productEntity = this.productRepository.GetById(id);
            if (productEntity == null)
            {
                return null;
            }

            var manufacturer = new ManufacturerModel(productEntity.Manufacturer.Id, productEntity.Manufacturer.Name);
            var category = new CategoryModel(productEntity.Title.Category.Id, productEntity.Title.Category.Name);
            var title = new ProductTitleModel(productEntity.Title.Id, productEntity.Title.Title, productEntity.Title.CategoryId, category);

            return new ProductModel(
                productEntity.Id,
                productEntity.TitleId,
                productEntity.ManufacturerId,
                productEntity.UnitPrice,
                productEntity.Description,
                title,
                manufacturer);
        }

        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="model">The product model to update.</param>
        public void Update(AbstractModel model)
        {
            var x = (ProductModel)model;
            var productEntity = this.productRepository.GetById(x.Id);
            if (productEntity != null)
            {
                productEntity.Id = x.Id;
                productEntity.TitleId = x.TitleId;
                productEntity.ManufacturerId = x.ManufacturerId;
                productEntity.UnitPrice = x.UnitPrice;
                productEntity.Description = x.Description;

                this.productRepository.Update(productEntity);
            }
        }

        /// <summary>
        /// Return count of the enteties in the specyfic DbSet.
        /// </summary>
        public int Count()
        {
            return this.productRepository.Count();
        }
    }
}
