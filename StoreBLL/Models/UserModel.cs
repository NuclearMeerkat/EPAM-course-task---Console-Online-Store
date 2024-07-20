namespace StoreBLL.Models;
using System;
using System.Collections.Generic;

public class UserModel : AbstractModel
{
    public UserModel(int id, string name, string lastName, string login, string password, int roleId)
        : base(id)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Login = login;
        this.Password = password;
        this.RoleId = roleId;
    }

    public UserModel(string name, string lastName, string login, string password, int roleId)
        : base(0)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Login = login;
        this.Password = password;
        this.RoleId = roleId;
    }

    public UserModel()
        : base(0)
    {
    }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }

    public List<CustomerOrderModel>? Orders { get; set; } // From Order entity

    public override string? ToString()
    {
        return $"ID:{this.Id,-8} Name: {this.Name,-15} Last name: {this.LastName,-15} Login: {this.Login,-15}";
    }
}
