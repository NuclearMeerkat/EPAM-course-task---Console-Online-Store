namespace StoreBLL.Models;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

public class CustomerOrderModel : AbstractModel
{
    public CustomerOrderModel(int id, string orderDate, int orderStateId, int userId)
        : base(id)
    {
        Id = id;
        OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        UserId = userId;
    }

    public CustomerOrderModel(int id, string orderDate, int orderStateId, int userId, string state)
        : base(id)
    {
        Id = id;
        OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        UserId = userId;
        State = state;
    }

    public CustomerOrderModel() : base(0) { }

    public int Id { get; set; }

    public int UserId { get; set; }

    public string OperationTime { get; set; }

    public int OrderStateId { get; set; }

    public string State { get; set; }

    public List<OrderDetailModel> OrderDetails { get; set; }
}
