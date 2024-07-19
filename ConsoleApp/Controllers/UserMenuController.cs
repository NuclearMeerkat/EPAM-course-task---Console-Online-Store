using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
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
    private static StoreDbContext context;

    public static int UserId { get; private set; }

    public static UserRoles UserRole { get; private set; }

    static UserMenuController()
    {
        UserId = 0;
        UserRole = UserRoles.Guest;
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

        UserId = user.Id;

        if (roleId == 1)
        {
            UserRole = UserRoles.Administrator;
        }
        else if (roleId == 2)
        {
            UserRole = UserRoles.RegistredCustomer;
        }
        else
        {
            Console.WriteLine("Invalid credentials, logging in as Guest.");
            UserId = 0;
            UserRole = UserRoles.Guest;
        }
    }

    public static void Logout()
    {
        UserId = 0;
        UserRole = UserRoles.Guest;
    }

    public static void ShowAllProductTitles()
    {
        Console.Clear();
        UserController.ShowAllProductTitles();
    }

    public static void Register()
    {
        Console.Clear();
        UserController.AddUser();
        Console.Clear();
        Logout();
    }

    public static void Start()
    {
        ConsoleKey resKey;
        bool updateItems = true;
        do
        {
                resKey = RolesToMenu[UserRole].RunOnce(ref updateItems);
        }
        while (resKey != ConsoleKey.Escape);
    }

    public static void ShowAllUserOrders()
    {
        ShopController.ShowAllUserOrders();
    }

    public static void CancelOrder()
    {
        ShopController.CancelOrder();
    }

    public static void ConfirmDelivery()
    {
        ShopController.ConfirmDelivery();
    }

    public static void AddProductTitle()
    {
        ProductController.AddProductTitle();
    }

    public static void ShowOrderList()
    {
        ShopController.ShowAllOrders();
    }

    public static void ChageOrderStatus()
    {
        ShopController.ChangeOrderStatus();
    }

    public static void ShowProductsByTitleId()
    {
        Console.Clear();
        ProductController.ShowProductsByTitleId();
        UserController.ShowAllProductTitles();
    }

    public static void AddOrderDetailsToChart()
    {
        ShopController.AddOrderDetailsToChart();
    }

    public static void ViewChart()
    {
        UserChartController.ViewUserChart(UserId);
    }

    public static void ConfirmOrder()
    {
        UserChartController.ConfirmOrder(UserId);
    }

    public static void ShowAllProducts()
    {
        ProductController.ShowAllProducts();
    }

    public static void DeleteOrderDetailFromChart()
    {
        UserChartController.DeleteOrderDetail(UserId);
    }
}