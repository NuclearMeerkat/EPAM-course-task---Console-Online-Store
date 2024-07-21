using System;
using System.Collections.Generic;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenu;
using StoreBLL.Interfaces;
using StoreBLL.Models;

namespace ConsoleMenu
{
    public class ContextMenu : Menu
    {
        private readonly Func<IEnumerable<AbstractModel>> getAll;

        public ContextMenu(ContextMenuHandler controller, Func<IEnumerable<AbstractModel>> getAll)
            : base(controller.GenerateMenuItems())
        {
            this.getAll = getAll;
        }

        public ContextMenu(Func<(ConsoleKey id, string caption, Action action)[]> generateMenuItems, Func<IEnumerable<AbstractModel>> getAll)
            : base(generateMenuItems())
        {
            this.getAll = getAll;
        }

        public override void Run()
        {
            ConsoleKey resKey;
            bool updateItems = true;
            do
            {
                if (updateItems)
                {
                    Console.WriteLine($"\n======= {this.getAll.Target.ToString().Split('.')[^1].Replace("Service", string.Empty)} ========");
                    foreach (var record in this.getAll())
                    {
                        Console.WriteLine(record.ToString());
                    }
                    Console.WriteLine("===================================");

                    foreach (var item in this.items)
                    {
                        Console.WriteLine($"<{item.Key}>:\t  {item.Value}");
                    }

                    Console.WriteLine("Or press <Esc> to return");
                    updateItems = false; // Ensure the dataset and menu items are printed only once per update
                }

                resKey = this.RunOnce(ref updateItems);
            }
            while (resKey != ConsoleKey.Escape);
            Console.Clear();
        }
    }
}
