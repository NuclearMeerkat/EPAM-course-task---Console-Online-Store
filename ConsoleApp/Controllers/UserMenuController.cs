using System.Diagnostics;
using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleMenu;
using ConsoleMenu.Builder;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;
using StoreDAL.Data.InitDataFactory;

namespace ConsoleApp1;

public enum UserRoles
{
    Guest,
    Administrator,
    RegistredCustomer,
}

public static class UserMenuController
{
    private static readonly Dictionary<UserRoles, Menu> RolesToMenu;
    private static int userId;
    private static UserRoles userRole;
    private static StoreDbContext context;

    static UserMenuController()
    {
        userId = 0;
        userRole = UserRoles.Guest;
        RolesToMenu = new Dictionary<UserRoles, Menu>();
        var factory = new StoreDbFactory(new TestDataFactory());
        context = factory.CreateContext();
        RolesToMenu.Add(UserRoles.Guest, new GuestMainMenu().Create(context));
        RolesToMenu.Add(UserRoles.RegistredCustomer, new UserMainMenu().Create(context));
        RolesToMenu.Add(UserRoles.Administrator, new AdminMainMenu().Create(context));
    }

    public static StoreDbContext Context
    {
        get { return context; }
    }

    public static void Login()
    {
        var user = UserController.LoginUser();
        var roleId = user.RoleId;

        userId = user.Id;

        if (roleId == 1)
        {
            userRole = UserRoles.Administrator;
        }
        else if (roleId == 2)
        {
            userRole = UserRoles.RegistredCustomer;
        }
        else
        {
            Console.WriteLine("Invalid credentials, logging in as Guest.");
            userId = 0;
            userRole = UserRoles.Guest;
        }
    }

    public static void Logout()
    {
        userId = 0;
        userRole = UserRoles.Guest;
    }

    public static void ShowAllProductTitles()
    {
        UserController.ShowAllProductTitles();
    }

    public static void Register()
    {
        UserController.AddUser();
        Logout();
    }

    public static void Start()
    {
        ConsoleKey resKey;
        bool updateItems = true;
        do
        {
                resKey = RolesToMenu[userRole].RunOnce(ref updateItems);
        }
        while (resKey != ConsoleKey.Escape);
    }

    public static void ShowAllUserOrders()
    {
        ShopController.ShowAllUserOrders(userId);
    }

    public static void CancelOrder()
    {
        ShopController.CancelOrder(userRole);
    }

    public static void ConfirmDelivery()
    {
        ShopController.ConfirmDelivery(userRole);
    }

    public static void AddProductTitle()
    {
        ProductController.AddProductTitle();
    }

    internal static void ShowOrderList()
    {
        ShopController.ShowAllOrders();
    }

    internal static void ChageOrderStatus()
    {
        ShopController.ChangeOrderStatus();
    }
}