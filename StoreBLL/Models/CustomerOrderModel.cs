namespace StoreBLL.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class CustomerOrderModel : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">The order ID.</param>
        /// <param name="orderDate">The date the order was placed.</param>
        /// <param name="orderStateId">The state ID of the order.</param>
        /// <param name="userId">The ID of the user who placed the order.</param>
        public CustomerOrderModel(int id, string? orderDate, int orderStateId, int userId)
            : base(id)
        {
            this.OperationTime = orderDate;
            this.OrderStateId = orderStateId;
            this.UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="orderDate">The date the order was placed.</param>
        /// <param name="orderStateId">The state ID of the order.</param>
        /// <param name="userId">The ID of the user who placed the order.</param>
        public CustomerOrderModel(string? orderDate, int orderStateId, int userId)
            : base(default)
        {
            this.OperationTime = orderDate;
            this.OrderStateId = orderStateId;
            this.UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">The order ID.</param>
        /// <param name="orderDate">The date the order was placed.</param>
        /// <param name="orderStateId">The state ID of the order.</param>
        /// <param name="userId">The ID of the user who placed the order.</param>
        /// <param name="state">The state of the order.</param>
        /// <param name="user">The user who placed the order.</param>
        public CustomerOrderModel(int id, string orderDate, int orderStateId, int userId, OrderStateModel state, UserModel user)
            : base(id)
        {
            this.OperationTime = orderDate;
            this.OrderStateId = orderStateId;
            this.UserId = userId;
            this.State = state;
            this.User = user;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderModel"/> class.
        /// </summary>
        public CustomerOrderModel()
            : base(0)
        {
        }

        /// <summary>
        /// Gets or sets the ID of the user who placed the order.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date the order was placed.
        /// </summary>
        public string? OperationTime { get; set; }

        /// <summary>
        /// Gets or sets the state ID of the order.
        /// </summary>
        public int OrderStateId { get; set; }

        /// <summary>
        /// Gets or sets the state of the order.
        /// </summary>
        public OrderStateModel State { get; set; }

        /// <summary>
        /// Gets or sets the user who placed the order.
        /// </summary>
        public UserModel User { get; set; }

        /// <summary>
        /// Gets or sets the details of the order.
        /// </summary>
        public List<OrderDetailModel> OrderDetails { get; set; }

        /// <summary>
        /// Returns a string representation of the customer order.
        /// </summary>
        /// <returns>A string representation of the customer order.</returns>
        public override string? ToString()
        {
            return $"{"ID:" + this.Id,-7} {"Operation time:" + this.OperationTime,-35} {"Order status:" + this.State.StateName,-45} {"User:" + this.User.Login,-20}";
        }
    }
}
