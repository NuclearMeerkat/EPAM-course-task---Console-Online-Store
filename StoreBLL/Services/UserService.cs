namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

public class UserService : ICrud
{
    private readonly IUserRepository userRepository;

    public UserService(StoreDbContext context)
    {
        this.userRepository = new UserRepository(context);
    }

    public UserModel Login(string login, string password)
    {
        var userEntity = userRepository.GetUserByLogin(login);

        if (userEntity == null)
        {
            return null;
        }

        bool isPasswordValid = false;

        try
        {
            isPasswordValid = BCrypt.Net.BCrypt.Verify(password, userEntity.Password);
        }
        catch (BCrypt.Net.SaltParseException)
        {
            if (password == userEntity.Password)
            {
                isPasswordValid = true;
            }
        }

        if (!isPasswordValid)
        {
            return null;
        }

        return new UserModel
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            LastName = userEntity.LastName,
            Login = userEntity.Login,
            RoleId = userEntity.RoleId,
        };
    }

    public void Add(AbstractModel model)
    {
        var x = (UserModel)model;
        var userEntity = new User
        {
            Name = x.Name,
            LastName = x.LastName,
            Login = x.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(x.Password),
            RoleId = x.RoleId,
        };
        this.userRepository.Add(userEntity);
    }

    public void Delete(int modelId)
    {
        this.userRepository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        var userEntities = this.userRepository.GetAll();
        return userEntities.Select(u => new UserModel
        {
            Id = u.Id,
            Name = u.Name,
            LastName = u.LastName,
            Login = u.Login,
            Password = u.Password,
            RoleId = u.RoleId,
        });
    }

    public AbstractModel GetById(int id)
    {
        var userEntity = this.userRepository.GetById(id);
        if (userEntity == null)
        {
            return null;
        }

        return new UserModel
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            LastName = userEntity.LastName,
            Login = userEntity.Login,
            Password = userEntity.Password,
            RoleId = userEntity.RoleId,
        };
    }

    public void Update(AbstractModel model)
    {
        var x = (UserModel)model;
        var userEntity = this.userRepository.GetById(x.Id);
        if (userEntity != null)
        {
            userEntity.Name = x.Name;
            userEntity.LastName = x.LastName;
            userEntity.Login = x.Login;
            if (!string.IsNullOrEmpty(x.Password))
            {
                userEntity.Password = BCrypt.Net.BCrypt.HashPassword(x.Password);
            }
            userEntity.RoleId = x.RoleId;

            this.userRepository.Update(userEntity);
        }
    }
}
