using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ConsoleApp.Handlers.ContextMenu;
using ConsoleApp.Helpers;
using ConsoleApp.Services;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;

namespace ConsoleApp.Controllers
{
    /// <summary>
    /// Controller for managing products and related entities.
    /// </summary>
    public static class ProductController
    {
        private static StoreDbContext context = UserMenuController.Context;

        /// <summary>
        /// Shows details of a single product and then show dataset of all other products.
        /// </summary>
        public static void ShowProduct()
        {
            var productService = new ProductService(context);

            Console.WriteLine("Please, enter id of the product:");
            int id = ValidationHelper.ReadValidId(productService);

            Console.WriteLine(productService.GetById(id));
        }

        /// <summary>
        /// Shows all products and transfers you to Guest menu.
        /// </summary>
        public static void ShowAllProducts()
        {
            var productService = new ProductService(context);
            var menu = new ContextMenu(new ShoppingContextMenuHandler(productService, InputHelper.ReadOrderStateModel), productService.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Shows all products related to the title id entered by the user.
        /// </summary>
        public static void ShowProductsByTitleId()
        {
            var productService = new ProductService(context);
            var titleService = new ProductTitleService(context);

            Console.WriteLine("Input record ID for more details");
            int id = ValidationHelper.ReadValidId(titleService);
            Console.WriteLine();
            Console.Clear();

            var title = (ProductTitleModel)titleService.GetById(id);
            var products = productService.GetAllByTitle(id).Select(p => (ProductModel)p);

            Console.WriteLine($"*** {title.Title} ***");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("*****************************************\n");
        }

        /// <summary>
        /// Shows all categories.
        /// </summary>
        public static void ShowAllCategories()
        {
            var productService = new CategoryService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(productService, InputHelper.ReadCategoryModel), productService.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Adds a new product title.
        /// </summary>
        public static void AddProductTitle()
        {
            var productTitleService = new ProductTitleService(context);
            var productTitleModel = InputHelper.ReadProductTitleModel();
            if (productTitleModel != null)
            {
                productTitleService.Add(productTitleModel);
                Console.WriteLine("Product has been successfully added to the catalog");
            }
        }

        /// <summary>
        /// Shows all product titles, transfers you to Order menu.
        /// </summary>
        public static void ShowAllProductTitles()
        {
            var productService = new ProductTitleService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(productService, InputHelper.ReadProductTitleModel), productService.GetAll);
            menu.Run();
        }
    }
}
