namespace StoreBLL.Models;
using System;
using System.Collections.Generic;

public class OrderModel : AbstractModel
{
    public OrderModel(int id, string orderDate, decimal totalAmount)
        : base(id)
    {
        Id = id;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
    }

    public int Id { get; set; }
    public string OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
