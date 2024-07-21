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

            Console.Clear();
            Console.WriteLine("User Login: ");
            var login = ValidationHelper.ReadValidString();
            Console.Clear();

            Console.WriteLine("Password: ");
            var password = ValidationHelper.ReadValidString();
            Console.Clear();

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

            return user;
        }

        /// <summary>
        /// Shows all users.
        /// </summary>
        public static void ShowAllUsers()
        {
            Console.Clear();
            var service = new UserService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadUserModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Shows all user roles.
        /// </summary>
        public static void ShowAllUserRoles()
        {
            Console.Clear();
            var service = new UserRoleService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadUserRoleModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Shows all product titles with details.
        /// </summary>
        public static void ShowAllProductTitles()
        {
            var productService = new ProductTitleService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(productService, InputHelper.ReadProductTitleModel), productService.GetAll);
            menu.Run();
        }

        public static void ShowAllProductTitlesForGuest()
        {
            var productService = new ProductTitleService(context);
            var menu = new ContextMenu(new GuestContextMenuHandler(productService, InputHelper.ReadProductTitleModel), productService.GetAll);
            menu.Run();
        }
    }
}
