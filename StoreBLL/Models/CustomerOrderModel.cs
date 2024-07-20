namespace StoreBLL.Models;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

public class CustomerOrderModel : AbstractModel
{
    public CustomerOrderModel(int id, string orderDate, int orderStateId, int userId)
        : base(id)
    {
        this.OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        this.UserId = userId;
    }

    public CustomerOrderModel(string orderDate, int orderStateId, int userId)
        : base(default)
    {
        this.OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        this.UserId = userId;
    }

    public CustomerOrderModel(int id, string orderDate, int orderStateId, int userId, OrderStateModel state, UserModel user)
        : base(id)
    {
        this.OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        this.UserId = userId;
        this.State = state;
        this.User = user;
    }

    public CustomerOrderModel()
        : base(0)
    {
    }

    public int UserId { get; set; }

    public string OperationTime { get; set; }

    public int OrderStateId { get; set; }

    public OrderStateModel State { get; set; }

    public UserModel User { get; set; }

    public List<OrderDetailModel> OrderDetails { get; set; }

    public override string? ToString()
    {
        return $"{"ID:" + this.Id,-7} {"Operation time:" + this.OperationTime,-35} {"Order status:" + this.State.StateName,-45} {"User:" + this.User.Login,-20}";
    }
}
