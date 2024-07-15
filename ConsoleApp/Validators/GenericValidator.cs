using StoreBLL.Models;
using StoreBLL.Interfaces;
using StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using StoreDAL.Data;
using StoreBLL.Services;

namespace ConsoleApp.Validators
{
    public class GenericValidator<T> where T : AbstractModel
    {
        private static StoreDbContext context = UserMenuController.Context;

        public static bool ValidateEntityId(int id)
        {
            var service = new UserService(context);
            return service.GetById(id) != null;
        }
    }
}
