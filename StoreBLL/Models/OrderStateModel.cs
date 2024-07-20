namespace StoreBLL.Models;
using System;
using System.Collections.Generic;

public class OrderStateModel : AbstractModel
{
    public OrderStateModel(int id, string stateName)
        : base(id)
    {
        this.StateName = stateName;
    }

    public OrderStateModel(string stateName)
        : base(default)
    {
        this.StateName = stateName;
    }

    public OrderStateModel()
        : base(0)
    {
    }

    public string StateName { get; set; }

    public override string ToString()
    {
        return $"Id:{this.Id,-5} State name:{this.StateName,-30}";
    }
}