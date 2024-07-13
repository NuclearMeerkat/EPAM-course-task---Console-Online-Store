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
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly DbSet<User> dbSet;

        public UserRepository(StoreDbContext context)
            : base(context)
        {
            this.dbSet = this.context.Set<User>();
        }

        public void Add(User entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(User entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = dbSet.Find(id);
            if (user != null)
            {
                this.dbSet.Remove(user);
                this.context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return this.dbSet
                .Include(u => u.Role)
                .Include(u => u.Orders)
                .ToList();
        }

        public IEnumerable<User> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                .Include(u => u.Role)
                .Include(u => u.Orders)
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
        }

        public User GetById(int id)
        {
            return this.dbSet
                .Include(u => u.Role)
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Update(User entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
