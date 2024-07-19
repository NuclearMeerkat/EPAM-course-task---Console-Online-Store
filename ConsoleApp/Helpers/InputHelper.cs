namespace ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Models;
using StoreBLL.Services;
using ConsoleApp1;
using StoreDAL.Data;
using ConsoleApp.Controllers;
using System.Data;

internal static class InputHelper
{
    private static StoreDbContext context = UserMenuController.Context;

    public static CategoryModel ReadCategoryModel()
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
        var category = new CategoryService(context);

        Console.WriteLine("Input title name");
        var title = Console.ReadLine();
        Console.WriteLine("Input required category id");
        ProductController.ShowAllCategories();

        int categoryId;

        if (!int.TryParse(Console.ReadLine(), out categoryId))
        {
            Console.WriteLine("Not valid value, please, enter digit number");
            return null;
        }
        else if (category.GetById(categoryId) == null)
        {
            Console.WriteLine("Category with this ID is not existing");
            return null;
        }
        return new ProductTitleModel(title, categoryId);
    }

    public static UserModel ReadUserModel()
    {
        Console.WriteLine("Input your name");
        var name = Console.ReadLine();
        Console.WriteLine("Input your last name");
        var lastName = Console.ReadLine();
        Console.WriteLine("Input you login");
        var login = Console.ReadLine();
        Console.WriteLine("Enter your password");
        var password = Console.ReadLine();
        Console.WriteLine("Input your role id (1 - Guest, 2 - User, 3 - admin)");
        int roleId;
        bool checkIfValidInput = false;
        do
        {
            checkIfValidInput = int.TryParse(Console.ReadLine(), out roleId);
            if (!checkIfValidInput || roleId < 1 || roleId > 3)
            {
                checkIfValidInput = false;
                Console.WriteLine("Not valid role id, try again:");
            }
        } while (!checkIfValidInput);

        return new UserModel(name, lastName, login, password, roleId);
    }
}
