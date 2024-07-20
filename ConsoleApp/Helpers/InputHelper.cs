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
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreBLL.Interfaces;
using System.Xml.Linq;
using StoreDAL.Entities;

internal static class InputHelper
{
    private static StoreDbContext context = UserMenuController.Context;

    public static CategoryModel ReadCategoryModel()
    {
        Console.Clear();
        Console.WriteLine("Enter category name:");
        string name = ValidationHelper.ReadValidString();
        Console.Clear();

        return new CategoryModel(name);
    }

    public static ProductModel ReadProductModel()
    {
        var productTitleService = new ProductTitleService(context);
        var manufacturerService = new ManufacturerService(context);

        Console.Clear();
        GetAll(productTitleService);
        Console.WriteLine("Enter Product title id:");
        var titleId = ValidationHelper.ReadValidId(productTitleService);
        Console.Clear();

        GetAll(manufacturerService);
        Console.WriteLine("Enter Manufacturer id:");
        var maufacturerId = ValidationHelper.ReadValidId(manufacturerService);
        Console.Clear();

        Console.WriteLine("Enter the price of one unit:");
        var price = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Clear();

        Console.WriteLine("Enter the description:");
        string description = ValidationHelper.ReadValidString();
        Console.Clear();

        return new ProductModel(titleId, maufacturerId, price, description);
    }

    public static OrderStateModel ReadOrderStateModel()
    {
        Console.Clear();
        Console.WriteLine("Input State Name");
        string name = ValidationHelper.ReadValidString();

        return new OrderStateModel(name);
    }

    public static UserRoleModel ReadUserRoleModel()
    {
        Console.Clear();
        Console.WriteLine("Input User Role Name");
        var name = ValidationHelper.ReadValidString();
        return new UserRoleModel(name);
    }

    public static ProductTitleModel ReadProductTitleModel()
    {
        var category = new CategoryService(context);

        Console.Clear();
        Console.WriteLine("Input title description");
        var title = ValidationHelper.ReadValidString();
        Console.Clear();

        GetAll(category);
        Console.WriteLine("Input required category id");
        int categoryId = ValidationHelper.ReadValidId(category);

        return new ProductTitleModel(title, categoryId);
    }

    public static UserModel ReadUserModel()
    {
        var userRoleService = new UserRoleService(context);

        Console.Clear();
        Console.WriteLine("Input name");
        var name = ValidationHelper.ReadValidString();
        Console.Clear();

        Console.WriteLine("Input last name");
        var lastName = ValidationHelper.ReadValidString();
        Console.Clear();

        Console.WriteLine("Input login");
        var login = ValidationHelper.ReadValidString();
        Console.Clear();

        Console.WriteLine("Enter password");
        var password = ValidationHelper.ReadValidString();
        Console.Clear();

        GetAll(userRoleService);
        Console.WriteLine("Input your role id (1 - Admin, 2 - User, 3 - Guest)");
        int roleId = ValidationHelper.ReadValidId(userRoleService);
        Console.Clear();

        return new UserModel(name, lastName, login, password, roleId);
    }

    public static AbstractModel ReadCustomerOrderModel()
    {
        var userService = new UserService(context);
        var orderStateService = new OrderStateService(context);

        Console.Clear();
        GetAll(userService);
        Console.WriteLine("Enter ID of the user you want to connect:");
        int userId = ValidationHelper.ReadValidId(userService);
        Console.Clear();

        GetAll(orderStateService);
        Console.WriteLine("Enter order state ID:");
        int stateId = ValidationHelper.ReadValidId(orderStateService);
        Console.Clear();

        Console.WriteLine("Enter operation time (as a string):");
        string operationTime = ValidationHelper.ReadValidString();
        Console.Clear();

        return new CustomerOrderModel(operationTime, stateId, userId);
    }

    public static CustomerOrderModel ReadOrderWithNewStatus()
    {
        var orderService = new CustomerOrderService(context);
        var orderStateService = new OrderStateService(context);

        Console.Clear();
        GetAll(orderService);
        Console.WriteLine("Enter ID of your order");
        int orderId = ValidationHelper.ReadValidId(orderService);
        Console.Clear();

        GetAll(orderStateService);
        Console.WriteLine("Enter ID of the required status");
        int status = ValidationHelper.ReadValidId(orderStateService);
        Console.Clear();

        var order = (CustomerOrderModel)orderService.GetById(orderId);
        order.OrderStateId = status;

        return order;
    }

    /// <summary>
    /// Method to show all members from one of the DB sets.
    /// </summary>
    /// <param text="userRoleService">ICrud obje</param>
    private static void GetAll(ICrud service)
    {
        foreach (var item in service.GetAll())
        {
            Console.WriteLine(item);
        }
    }
}
