using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Handlers.ContextMenu;
using ConsoleApp.Helpers;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;

namespace ConsoleApp.Services
{
    /// <summary>
    /// Controller for managing users and related entities.
    /// </summary>
    public static class UserController
    {
        private static StoreDbContext context = UserMenuController.Context;

        /// <summary>
        /// Adds a new user.
        /// </summary>
        public static void AddUser()
        {
            var userService = new UserService(context);
            var userModel = InputHelper.ReadUserModel();
            userService.Add(userModel);
            Console.WriteLine("User added");
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <returns>The logged-in user model.</returns>
        public static UserModel LoginUser()
        {
            UserModel user = new UserModel();
            Console.WriteLine("LoginUser: ");
            var login = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            if (!string.IsNullOrEmpty(login) || !string.IsNullOrEmpty(password))
            {
                var userService = new UserService(context);
                if (userService.LoginUser(login, password) != null)
                {
                    user = userService.LoginUser(login, password);
                    Console.WriteLine("User exists");
                }
                else
                {
                    Console.WriteLine("Wrong login or password. Try to login again");
                }
            }

            return user;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        public static void UpdateUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        public static void DeleteUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows details of a single user.
        /// </summary>
        public static void ShowUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all users.
        /// </summary>
        public static void ShowAllUsers()
        {
            var userService = new UserService(context);
            var users = userService.GetAll().Select(u => (UserModel)u);
            Console.WriteLine("======= Current DataSet ==========");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, LastName: {user.LastName}, LoginUser: {user.Login}, RoleId: {user.RoleId}");
            }
            Console.WriteLine("===================================");
        }

        /// <summary>
        /// Adds a new user role.
        /// </summary>
        public static void AddUserRole()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing user role.
        /// </summary>
        public static void UpdateUserRole()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a user role.
        /// </summary>
        public static void DeleteUserRole()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all user roles.
        /// </summary>
        public static void ShowAllUserRoles()
        {
            var userService = new UserRoleService(context);
            var userRoles = userService.GetAll().Select(u => (UserRoleModel)u);
            Console.WriteLine("======= Current DataSet ==========");
            foreach (var role in userRoles)
            {
                Console.WriteLine($"ID: {role.Id}, Name: {role.RoleName}");
            }
            Console.WriteLine("===================================");
        }

        /// <summary>
        /// Adds a new product title.
        /// </summary>
        public static void AddProductTitle()
        {
            throw new NotImplementedException();
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
            var productService = new ProductTitleService(context);
            var menu = new ContextMenu(new GuestContextMenuHandler(productService, InputHelper.ReadOrderStateModel), productService.GetAll);
            menu.Run();
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
