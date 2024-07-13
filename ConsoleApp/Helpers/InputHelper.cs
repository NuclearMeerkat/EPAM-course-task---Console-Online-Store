namespace ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Models;

internal static class InputHelper
{
    public static CategoryModel ReadCategoryiModel()
    {
        throw new NotImplementedException();
    }

    public static ManufacturerModel ReadManufacturerModel()
    {
        throw new NotImplementedException();
    }

    public static OrderStateModel ReadOrderStateModel()
    {
        Console.WriteLine("Input State Id");
        var id = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Input State Name");
        var name = Console.ReadLine();
        return new OrderStateModel(id, name);
    }

    public static UserRoleModel ReadUserRoleModel()
    {
        Console.WriteLine("Input User Role Id");
        var id = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Input User Role Name");
        var name = Console.ReadLine();
        return new UserRoleModel(id, name);
    }

    public static ProductTitleModel ReadProductTitleModel()
    {
        Console.WriteLine("Input new title id");
        var id = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Input title name");
        var title = Console.ReadLine();
        Console.WriteLine("Input category id");
        var categoryId = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        return new ProductTitleModel(id, title, categoryId);
    }

    public static UserModel ReadUserModel()
    {
        Console.WriteLine("Input your unic id");
        var id = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Input your name");
        var name = Console.ReadLine();
        Console.WriteLine("Input your last name");
        var lastName = Console.ReadLine();
        Console.WriteLine("Input you login");
        var login = Console.ReadLine();
        Console.WriteLine("Enter your password");
        var password = Console.ReadLine();
        Console.WriteLine("Input your role id (1 - Guest, 2 - User, 3 - admin)");
        var RoleId = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        return new UserModel(id, name, lastName, login, password, RoleId);
    }
}
