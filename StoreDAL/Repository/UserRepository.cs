using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using BCrypt;
using StoreDAL.Data;

namespace StoreDAL.Repository
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly DbSet<User> dbSet;

        public UserRepository(StoreDbContext context)
            : base(context)
        {
            this.dbSet = context.Set<User>();
        }

        public void Add(User entity)
        {
            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public IEnumerable<User> GetAll(int pageNumber, int rowCount)
        {
            return context.Users
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
        }

        public User GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(User entity)
        {
            var existingUser = context.Users.Find(entity.Id);
            if (existingUser != null)
            {
                existingUser.Name = entity.Name;
                existingUser.LastName = entity.LastName;
                existingUser.Login = entity.Login;
                existingUser.RoleId = entity.RoleId;

                if (!string.IsNullOrEmpty(entity.Password))
                {
                    existingUser.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
                }

                context.Users.Update(existingUser);
                context.SaveChanges();
            }
        }
    }
}
