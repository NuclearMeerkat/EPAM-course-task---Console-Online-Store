using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

namespace StoreDAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(StoreDbContext context)
            : base(context)
        {
        }

        public User GetUserByLogin(string login)
        {
            return this.dbSet.SingleOrDefault(user => user.Login == login);
        }
    }
}
