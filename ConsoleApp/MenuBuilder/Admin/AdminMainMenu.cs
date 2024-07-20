using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

public class AdminMainMenu : AbstractMenuCreator
{
    public override (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context)
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.F1, "Logout", UserMenuController.Logout),
                (ConsoleKey.F2, "Shop menu", () => { UserMenuController.ShowShopMenu(); }),
                (ConsoleKey.F3, "Show order list", () => { UserMenuController.ShowOrderList(); }),
                (ConsoleKey.F4, "Cancel order", () => { UserMenuController.CancelOrder(); }),
                (ConsoleKey.F5, "Change order status", () => { UserMenuController.ChageOrderStatus(); }),
                (ConsoleKey.F6, "Orders states", ShopController.ShowAllOrderStates),
                (ConsoleKey.F7, "Show product title list", () => { UserMenuController.ShowAllProductTitles(); }),
                (ConsoleKey.F7, "Show categories list", () => { UserMenuController.ShowAllCategories(); }),
                (ConsoleKey.F8, "Show all products", UserMenuController.ShowAllProducts),
                (ConsoleKey.F9, "User roles", UserController.ShowAllUserRoles),
                (ConsoleKey.F10, "Show all users", UserController.ShowAllUsers),
            };
        return array;
    }
}