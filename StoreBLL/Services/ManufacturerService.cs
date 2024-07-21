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
    /// Provides CRUD operations for Manufacturer entities.
    /// </summary>
    public class ManufacturerService : ICrud
    {
        private readonly IManufacturerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public ManufacturerService(StoreDbContext context)
        {
            this.repository = new ManufacturerRepository(context);
        }

        /// <summary>
        /// Adds a new manufacturer.
        /// </summary>
        /// <param name="model">The manufacturer model to add.</param>
        public void Add(AbstractModel model)
        {
            var x = (ManufacturerModel)model;
            this.repository.Add(new Manufacturer(0, x.Name));
        }

        /// <summary>
        /// Deletes a manufacturer by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the manufacturer to delete.</param>
        public void Delete(int modelId)
        {
            this.repository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all manufacturers.
        /// </summary>
        /// <returns>An enumerable collection of manufacturer models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var manufacturerEntities = this.repository.GetAll();
            return manufacturerEntities.Select(x => new ManufacturerModel(
                x.Id,
                x.Name));
        }

        /// <summary>
        /// Retrieves a manufacturer by its ID.
        /// </summary>
        /// <param name="id">The ID of the manufacturer to retrieve.</param>
        /// <returns>The manufacturer model with the specified ID, or null if not found.</returns>
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

        /// <summary>
        /// Updates an existing manufacturer.
        /// </summary>
        /// <param name="model">The manufacturer model with updated data.</param>
        public void Update(AbstractModel model)
        {
            var x = (ManufacturerModel)model;
            var manufacturerEntity = this.repository.GetById(x.Id);
            if (manufacturerEntity != null)
            {
                manufacturerEntity.Name = x.Name;

                this.repository.Update(manufacturerEntity);
            }
        }

        /// <summary>
        /// Returns the count of manufacturers in the database.
        /// </summary>
        /// <returns>The count of manufacturers.</returns>
        public int Count()
        {
            return this.repository.Count();
        }
    }
}
