namespace ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenu;
using ConsoleApp.Helpers;
using ConsoleMenu;
using StoreDAL.Data;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Repository;

public static class UserController
{
    private static StoreDbContext context = UserMenuController.Context;

    public static void AddUser()
    {
        var userService = new UserService(context);
        var userModel = InputHelper.ReadUserModel();
        userService.Add(userModel);
        Console.WriteLine("UserAdded");
    }

    public static UserModel LoginUser()
    {
        UserModel user = new UserModel();
        Console.WriteLine("Login: ");
        var login = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();

        if (!string.IsNullOrEmpty(login) || !string.IsNullOrEmpty(password))
        {
            var userService = new UserService(context);
            if (userService.Login(login, password) != null)
            {
                user = userService.Login(login, password);
                Console.WriteLine("User existing");
            }
            else
            {
                Console.WriteLine("Wrong login or password. Try to login again");
            }
        }

        return user;
    }

    public static void UpdateUser()
    {
        throw new NotImplementedException();
    }

    public static void DeleteUser()
    {
        throw new NotImplementedException();
    }

    public static void ShowUser()
    {
        throw new NotImplementedException();
    }

    public static void ShowAllUsers()
    {
        var userService = new UserService(context);
        var users = userService.GetAll().Select(u => (UserModel)u);
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, LastName: {user.LastName}, Login: {user.Login}, RoleId: {user.RoleId}");
        }
    }

    public static void AddUserRole()
    {
        throw new NotImplementedException();
    }

    public static void UpdateUserRole()
    {
        throw new NotImplementedException();
    }

    public static void DeleteUserRole()
    {
        throw new NotImplementedException();
    }

    public static void ShowAllUserRoles()
    {
        var rolesService = new UserRoleService(context);
        var menu = new ContextMenu(new AdminContextMenuHandler(rolesService, InputHelper.ReadUserRoleModel), rolesService.GetAll);
        menu.Run();
    }

    public static void AddProductTitle()
    {
        throw new NotImplementedException();
    }

    public static void UpdateProductTitle()
    {
        throw new NotImplementedException();
    }

    public static void DeleteProductTitle()
    {
        throw new NotImplementedException();
    }

    public static void ShowAllProductTitles()
    {
        var productService = new ProductTitleService(context);
        var products = productService.GetAll().Select(u => (ProductTitleModel)u);
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id} {product.Title} {product.CategoryId}");
        }
    }

    public static void AddManufacturer()
    {
        throw new NotImplementedException();
    }

    public static void UpdateManufacturer()
    {
        throw new NotImplementedException();
    }

    public static void DeleteManufacturer()
    {
        throw new NotImplementedException();
    }

    public static void ShowAllManufacturers()
    {
        throw new NotImplementedException();
    }
}
