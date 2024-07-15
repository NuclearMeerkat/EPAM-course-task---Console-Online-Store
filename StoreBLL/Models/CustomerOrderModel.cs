﻿namespace StoreBLL.Models;

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

    public CustomerOrderModel(string orderDate, int orderStateId, int userId)
        : base(default)
    {
        OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        UserId = userId;
    }


    public CustomerOrderModel(int id, string orderDate, int orderStateId, int userId, OrderStateModel state, UserModel user)
        : base(id)
    {
        this.Id = id;
        this.OperationTime = orderDate;
        this.OrderStateId = orderStateId;
        this.UserId = userId;
        this.State = state;
        this.User = user;
    }

    public CustomerOrderModel() : base(0) { }

    public int Id { get; set; }

    public int UserId { get; set; }

    public string OperationTime { get; set; }

    public int OrderStateId { get; set; }

    public OrderStateModel State{get; set; }

    public UserModel User { get; set; }

    public List<OrderDetailModel> OrderDetails { get; set; }

    public override string? ToString()
    {
        return $"ID: {Id} Date:{OperationTime} State:{State.StateName} User:{User.Login}";
    }
}
