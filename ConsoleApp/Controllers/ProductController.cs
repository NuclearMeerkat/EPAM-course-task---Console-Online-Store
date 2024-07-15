using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Helpers;
using ConsoleApp1;
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
        /// Adds a new product.
        /// </summary>
        public static void AddProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        public static void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        public static void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows details of a single product.
        /// </summary>
        public static void ShowProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all products.
        /// </summary>
        public static void ShowAllProducts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        public static void AddCategory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        public static void UpdateCategory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        public static void DeleteCategory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all categories.
        /// </summary>
        public static void ShowAllCategories()
        {
            var categoryService = new CategoryService(context);
            var categories = categoryService.GetAll().Select(u => (CategoryModel)u);
            Console.WriteLine("======= Current DataSet ==========");
            foreach (var category in categories)
            {
                Console.WriteLine($"CategoryID: {category.Id}, Name: {category.CategoryName}");
            }
            Console.WriteLine("===================================");
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
        /// Updates an existing product title.
        /// </summary>
        public static void UpdateProductTitle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a product title.
        /// </summary>
        public static void DeleteProductTitle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all product titles.
        /// </summary>
        public static void ShowAllProductTitles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a new manufacturer.
        /// </summary>
        public static void AddManufacturer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing manufacturer.
        /// </summary>
        public static void UpdateManufacturer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a manufacturer.
        /// </summary>
        public static void DeleteManufacturer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all manufacturers.
        /// </summary>
        public static void ShowAllManufacturers()
        {
            throw new NotImplementedException();
        }
    }
}
