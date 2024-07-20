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
    /// Provides services related to product titles, including CRUD operations.
    /// </summary>
    public class ProductTitleService : ICrud
    {
        private readonly IProductTitleRepository productTitleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTitleService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public ProductTitleService(StoreDbContext context)
        {
            this.productTitleRepository = new ProductTitleRepository(context);
        }

        /// <summary>
        /// Adds a new product title to the repository.
        /// </summary>
        /// <param name="model">The product title model to add.</param>
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

        /// <summary>
        /// Deletes a product title from the repository by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the product title to delete.</param>
        public void Delete(int modelId)
        {
            this.productTitleRepository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all product titles from the repository.
        /// </summary>
        /// <returns>A collection of product title models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var titleEntities = this.productTitleRepository.GetAll();
            return titleEntities.Select(x => new ProductTitleModel(
                x.Id,
                x.Title,
                x.CategoryId,
                new CategoryModel(x.CategoryId, x.Category.Name)));
        }

        /// <summary>
        /// Retrieves a product title by its ID.
        /// </summary>
        /// <param name="id">The ID of the product title to retrieve.</param>
        /// <returns>The product title model if found; otherwise, <c>null</c>.</returns>
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

        /// <summary>
        /// Updates an existing product title in the repository.
        /// </summary>
        /// <param name="model">The product title model to update.</param>
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

        /// <summary>
        /// Return count of the enteties in the specyfic DbSet.
        /// </summary>
        public int Count()
        {
            return this.productTitleRepository.Count();
        }
    }
}
