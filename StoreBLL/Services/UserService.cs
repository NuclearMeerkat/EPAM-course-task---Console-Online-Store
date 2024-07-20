namespace StoreBLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Scaffolding;
    using SQLitePCL;
    using StoreBLL.Interfaces;
    using StoreBLL.Models;
    using StoreDAL.Data;
    using StoreDAL.Entities;
    using StoreDAL.Interfaces;
    using StoreDAL.Repository;

    /// <summary>
    /// Provides services related to users, including authentication and CRUD operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public UserService(StoreDbContext context)
        {
            this.userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Retrieves a user by their login.
        /// </summary>
        /// <param name="login">The login of the user to retrieve.</param>
        /// <returns>The user model if found; otherwise, <c>null</c>.</returns>
        public UserModel GetUserByLogin(string login)
        {
            var userEntity = this.userRepository.GetUserByLogin(login);

            if (userEntity == null)
            {
                return null;
            }

            return new UserModel(
                userEntity.Id,
                userEntity.Name,
                userEntity.LastName,
                userEntity.Login,
                userEntity.Password,
                userEntity.RoleId);
        }

        /// <summary>
        /// Authenticates a user by their login and password.
        /// </summary>
        /// <param name="login">The login of the user to authenticate.</param>
        /// <param name="password">The password of the user to authenticate.</param>
        /// <returns>The user model if authentication is successful; otherwise, <c>null</c>.</returns>
        public UserModel LoginUser(string login, string password)
        {
            var userEntity = this.userRepository.GetUserByLogin(login);

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

            return new UserModel(
                userEntity.Id,
                userEntity.Name,
                userEntity.LastName,
                userEntity.Login,
                userEntity.Password,
                userEntity.RoleId);
        }

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="model">The user model to add.</param>
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

        /// <summary>
        /// Deletes a user from the repository by their ID.
        /// </summary>
        /// <param name="modelId">The ID of the user to delete.</param>
        public void Delete(int modelId)
        {
            this.userRepository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all users from the repository.
        /// </summary>
        /// <returns>A collection of user models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            var userEntities = this.userRepository.GetAll();
            return userEntities.Select(u => new UserModel(
                u.Id,
                u.Name,
                u.LastName,
                u.Login,
                u.Password,
                u.RoleId));
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user model if found; otherwise, <c>null</c>.</returns>
        public AbstractModel GetById(int id)
        {
            var userEntity = this.userRepository.GetById(id);
            if (userEntity == null)
            {
                return null;
            }

            return new UserModel(
                userEntity.Id,
                userEntity.Name,
                userEntity.LastName,
                userEntity.Login,
                userEntity.Password,
                userEntity.RoleId);
        }

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="model">The user model to update.</param>
        public void Update(AbstractModel model)
        {
            var x = (UserModel)model;
            var userEntity = this.userRepository.GetById(x.Id);
            if (userEntity != null)
            {
                userEntity.Id = x.Id;
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

        /// <summary>
        /// Return count of the enteties in the specyfic DbSet.
        /// </summary>
        public int Count()
        {
            return this.userRepository.Count();
        }
    }
}
