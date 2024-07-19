namespace StoreBLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.FlowAnalysis;
    using StoreBLL.Interfaces;
    using StoreBLL.Models;
    using StoreDAL.Data;
    using StoreDAL.Entities;
    using StoreDAL.Interfaces;
    using StoreDAL.Repository;

    /// <summary>
    /// Provides services related to customer orders, including CRUD operations.
    /// </summary>
    public class CustomerOrderService : ICrud
    {
        private readonly ICustomerOrderRepository customerOrderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public CustomerOrderService(StoreDbContext context)
        {
            this.customerOrderRepository = new CustomerOrderRepository(context);
        }

        /// <summary>
        /// Adds a new customer order to the repository.
        /// </summary>
        /// <param name="model">The customer order model to add.</param>
        public void Add(AbstractModel model)
        {
            var x = (CustomerOrderModel)model;
            var titleEntity = new CustomerOrder
            {
                Id = x.Id,
                UserId = x.UserId,
                OperationTime = DateTime.Now.ToString(),
                OrderStateId = x.OrderStateId,
            };
            this.customerOrderRepository.Add(titleEntity);
        }

        /// <summary>
        /// Deletes a customer order from the repository by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the customer order to delete.</param>
        public void Delete(int modelId)
        {
            this.customerOrderRepository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all customer orders from the repository.
        /// </summary>
        /// <returns>A collection of customer order models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var titleEntities = this.customerOrderRepository.GetAll();
            return titleEntities.Select(x => new CustomerOrderModel(
                x.Id,
                x.OperationTime,
                x.OrderStateId,
                x.UserId,
                new OrderStateModel(x.State.StateName),
                new UserModel(x.User.Name, x.User.LastName, x.User.Login, x.User.Password, x.User.RoleId)));
        }

        /// <summary>
        /// Retrieves customer orders by customer ID.
        /// </summary>
        /// <param name="userId">The ID of the customer.</param>
        /// <returns>A collection of customer order models.</returns>
        public IEnumerable<AbstractModel> GetOrdersByCustomerId(int userId)
        {
            var titleEntities = this.customerOrderRepository.GetOrdersByCustomerId(userId);
            return titleEntities.Select(x => new CustomerOrderModel(
                x.Id,
                x.OperationTime,
                x.OrderStateId,
                x.UserId,
                new OrderStateModel(x.State.StateName),
                new UserModel(x.User.Name, x.User.LastName, x.User.Login, x.User.Password, x.User.RoleId)));
        }

        /// <summary>
        /// Retrieves a customer order by its ID.
        /// </summary>
        /// <param name="id">The ID of the customer order to retrieve.</param>
        /// <returns>The customer order model if found; otherwise, <c>null</c>.</returns>
        public AbstractModel GetById(int id)
        {
            var res = this.customerOrderRepository.GetById(id);

            if (res == null)
            {
                return null;
            }

            return new CustomerOrderModel(res.Id, res.OperationTime, res.OrderStateId, res.UserId);
        }

        /// <summary>
        /// Updates an existing customer order in the repository.
        /// </summary>
        /// <param name="model">The customer order model to update.</param>
        public void Update(AbstractModel model)
        {
            var x = (CustomerOrderModel)model;
            var orderEntity = this.customerOrderRepository.GetById(x.Id);
            if (orderEntity != null)
            {
                orderEntity.OrderStateId = x.OrderStateId;
                orderEntity.UserId = x.UserId;
                orderEntity.OperationTime = x.OperationTime;

                this.customerOrderRepository.Update(orderEntity);
            }
        }
    }
}
