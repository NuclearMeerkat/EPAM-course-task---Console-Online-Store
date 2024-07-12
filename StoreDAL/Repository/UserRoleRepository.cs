namespace StoreDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

public class UserRoleRepository : AbstractRepository, IUserRoleRepository
{
    private readonly DbSet<UserRole> dbSet;

    public UserRoleRepository(StoreDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<UserRole>();
    }

    public void Add(UserRole entity)
    {
        this.dbSet.Add(entity);
        this.context.SaveChanges();
    }

    public void Delete(UserRole entity)
    {
        context.UserRoles.Remove(entity);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var entity = this.dbSet.Find(id);
        if (entity != null)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }
    }

    public IEnumerable<UserRole> GetAll()
    {
        return this.dbSet.ToList();
    }

    public IEnumerable<UserRole> GetAll(int pageNumber, int rowCount)
    {
        return context.UserRoles
                .Skip((pageNumber - 1) * rowCount)
                .Take(rowCount)
                .ToList();
    }

    public UserRole GetById(int id)
    {
        return this.dbSet.Find(id);
    }

    public void Update(UserRole entity)
    {
        var existingUserRole = context.UserRoles.Find(entity.Id);
        if (existingUserRole != null)
        {
            existingUserRole.RoleName = entity.RoleName;

            context.UserRoles.Update(existingUserRole);
            context.SaveChanges();
        }
    }
}