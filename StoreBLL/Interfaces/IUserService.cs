using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLL.Interfaces
{
    public interface IUserService : ICrud
    {
        public UserModel GetUserByLogin(string login);

        public UserModel LoginUser(string login, string password);
    }
}
