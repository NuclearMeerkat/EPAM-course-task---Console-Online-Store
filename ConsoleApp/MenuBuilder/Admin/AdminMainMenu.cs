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
                (ConsoleKey.F2, "Show product list", () => { UserMenuController.ShowAllProductTitles(); }),
                (ConsoleKey.F3, "Add product", () => { UserMenuController.AddProductTitle(); }),
                (ConsoleKey.F4, "Show order list", () => { UserMenuController.ShowOrderList(); }),
                (ConsoleKey.F5, "Cancel order", () => { UserMenuController.CancelOrder(); }),
                (ConsoleKey.F6, "Change order status", () => { UserMenuController.ChageOrderStatus(); }),
                (ConsoleKey.F7, "User roles", UserController.ShowAllUserRoles),
                (ConsoleKey.F8, "Orders states", ShopController.ShowAllOrderStates),
            };
        return array;
    }
}