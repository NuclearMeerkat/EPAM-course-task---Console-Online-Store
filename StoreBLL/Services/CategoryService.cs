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
    /// Provides services related to categories, including CRUD operations.
    /// </summary>
    public class CategoryService : ICrud
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public CategoryService(StoreDbContext context)
        {
            this.categoryRepository = new CategoryRepository(context);
        }

        /// <summary>
        /// Adds a new category to the repository.
        /// </summary>
        /// <param name="model">The category model to add.</param>
        /// <exception cref="NotImplementedException">Thrown because the method is not implemented yet.</exception>
        public void Add(AbstractModel model)
        {
            var x = (CategoryModel)model;
            this.categoryRepository.Add(new Category(0, x.CategoryName));
        }

        /// <summary>
        /// Deletes a category from the repository by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the category to delete.</param>
        /// <exception cref="NotImplementedException">Thrown because the method is not implemented yet.</exception>
        public void Delete(int modelId)
        {
            this.categoryRepository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all categories from the repository.
        /// </summary>
        /// <returns>A collection of category models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var titleEntities = this.categoryRepository.GetAll();
            return titleEntities.Select(x => new CategoryModel(
                x.Id,
                x.Name));
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The category model if found; otherwise, <c>null</c>.</returns>
        public AbstractModel GetById(int id)
        {
            var cateforyEntity = this.categoryRepository.GetById(id);
            if (cateforyEntity == null)
            {
                return null;
            }

            return new CategoryModel(
                cateforyEntity.Id,
                cateforyEntity.Name);
        }

        /// <summary>
        /// Updates an existing category in the repository.
        /// </summary>
        /// <param name="model">The category model to update.</param>
        /// <exception cref="NotImplementedException">Thrown because the method is not implemented yet.</exception>
        public void Update(AbstractModel model)
        {
            var x = (CategoryModel)model;
            var userEntity = this.categoryRepository.GetById(x.Id);
            if (userEntity != null)
            {
                userEntity.Name = x.CategoryName;

                this.categoryRepository.Update(userEntity);
            }
        }

        /// <summary>
        /// Return count of the enteties in the specyfic DbSet.
        /// </summary>
        public int Count()
        {
            return this.categoryRepository.Count();
        }
    }
}
