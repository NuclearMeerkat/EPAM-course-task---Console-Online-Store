﻿namespace ConsoleApp.Handlers.ContextMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Controllers;
using StoreBLL.Interfaces;
using StoreBLL.Models;

public class GuestContextMenuHandler : ContextMenuHandler
{
    public GuestContextMenuHandler(ICrud service, Func<AbstractModel> readModel)
        : base(service, readModel)
    {
    }

    public override (ConsoleKey id, string caption, Action action)[] GenerateMenuItems()
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.V, "View Details", ProductController.ShowProductsByTitleId),
            };
        return array;
    }
}