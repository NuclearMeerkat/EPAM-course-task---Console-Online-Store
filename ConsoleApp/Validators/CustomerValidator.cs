using ConsoleApp1;
using StoreBLL.Interfaces;
using StoreBLL.Services;
using StoreDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Validators
{
    public class CustomerValidator
    {
        private static StoreDbContext context = UserMenuController.Context;

        public static bool ValidateUserLogin(string login)
        {
            var userService = new UserService(context);
            return userService.GetUserByLogin(login) != null;
        }
    }
}
