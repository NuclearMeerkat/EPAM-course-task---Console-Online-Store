using ConsoleApp1;
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

public class UserMainMenu : AbstractMenuCreator
{
    public override (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context)
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.F1, "Logout", UserMenuController.Logout),
                (ConsoleKey.F2, "Show product list", () => { UserMenuController.ShowAllProductTitles(); }),
                (ConsoleKey.F3, "Show order list", () => { UserMenuController.ShowAllUserOrders(); }),
                (ConsoleKey.F4, "Cancel order", () => { UserMenuController.CancelOrder(); }),
                (ConsoleKey.F5, "Confirm order delivery", () => { UserMenuController.ConfirmDelivery(); }),
            };
        return array;
    }
}