using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

public class GuestMainMenu : AbstractMenuCreator
{
    public override (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context)
    {
        (ConsoleKey id, string caption, Action action)[] array =
        {
            (ConsoleKey.F1, "Login", () => { UserController.LoginUser(); }),
            (ConsoleKey.F2, "Show product list", () => { UserController.ShowAllProductTitles(); }),
            (ConsoleKey.F3, "Register", () => { UserController.AddUser(); }),
        };
        return array;
    }
}