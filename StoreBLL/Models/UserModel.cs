namespace StoreBLL.Models;
using System;
using System.Collections.Generic;

public class UserModel : AbstractModel
{
    public UserModel(int id, string name, string lastName, string login, string password, int roleId)
        : base(id)
    {
        Name = name;
        LastName = lastName;
        Login = login;
        Password = password;
        RoleId = roleId;
    }

    public UserModel() : base(0) { }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }

    public List<CustomerOrderModel>? Orders { get; set; } // From Order entity
}
