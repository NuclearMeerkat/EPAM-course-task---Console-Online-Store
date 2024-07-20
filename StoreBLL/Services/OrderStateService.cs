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
    /// Provides services related to order states, including CRUD operations.
    /// </summary>
    public class OrderStateService : ICrud
    {
        private readonly IOrderStateRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderStateService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public OrderStateService(StoreDbContext context)
        {
            this.repository = new OrderStateRepository(context);
        }

        /// <summary>
        /// Adds a new order state to the repository.
        /// </summary>
        /// <param name="model">The order state model to add.</param>
        public void Add(AbstractModel model)
        {
            var x = (OrderStateModel)model;
            this.repository.Add(new OrderState(x.Id, x.StateName));
        }

        /// <summary>
        /// Deletes an order state from the repository by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the order state to delete.</param>
        public void Delete(int modelId)
        {
            this.repository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all order states from the repository.
        /// </summary>
        /// <returns>A collection of order state models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var orderStateEntities = this.repository.GetAll();
            return orderStateEntities.Select(p => new OrderStateModel(
                p.Id,
                p.StateName));
        }

        /// <summary>
        /// Retrieves an order state by its ID.
        /// </summary>
        /// <param name="id">The ID of the order state to retrieve.</param>
        /// <returns>The order state model if found; otherwise, <c>null</c>.</returns>
        public AbstractModel GetById(int id)
        {
            var res = this.repository.GetById(id);
            if (res == null)
            {
                return null;
            }

            return new OrderStateModel(res.Id, res.StateName);
        }

        /// <summary>
        /// Updates an existing order state in the repository.
        /// </summary>
        /// <param name="model">The order state model to update.</param>
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

        /// <summary>
        /// Return count of the enteties in the specyfic DbSet.
        /// </summary>
        public int Count()
        {
            return this.repository.Count();
        }
    }
}
