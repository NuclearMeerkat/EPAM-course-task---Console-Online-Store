using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreBLL.Interfaces;
using StoreBLL.Models;

namespace ConsoleApp.Handlers.ContextMenu
{
    public class ShoppingContextMenuHandler : ContextMenuHandler
    {
        public ShoppingContextMenuHandler(ICrud service, Func<AbstractModel> readModel)
            : base(service, readModel)
        {

        }

        public void CreateOrder()
        {
            ShopController.AddOrder();

        }

        public override (ConsoleKey id, string caption, Action action)[] GenerateMenuItems()
        {
            (ConsoleKey id, string caption, Action action)[] array =
                {
                     (ConsoleKey.A, "Add item to chart", UserMenuController.AddOrderDetailsToChart),
                     (ConsoleKey.V, "View chart", UserMenuController.ViewChart),
                     (ConsoleKey.D, "Delete order from the chart", UserMenuController.DeleteOrderDetailFromChart),
                     (ConsoleKey.C, "Confirm order", UserMenuController.ConfirmOrder),

                };
            return array;
        }
    }
}
