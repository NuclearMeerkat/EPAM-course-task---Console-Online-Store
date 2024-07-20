namespace StoreBLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoreBLL.Interfaces;
    using StoreBLL.Models;
    using StoreDAL.Data;
    using StoreDAL.Entities;
    using StoreDAL.Interfaces;
    using StoreDAL.Repository;

    /// <summary>
    /// Provides services related to user roles, including CRUD operations.
    /// </summary>
    public class UserRoleService : ICrud
    {
        private readonly IUserRoleRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleService"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public UserRoleService(StoreDbContext context)
        {
            this.repository = new UserRoleRepository(context);
        }

        /// <summary>
        /// Adds a new user role to the repository.
        /// </summary>
        /// <param name="model">The user role model to add.</param>
        public void Add(AbstractModel model)
        {
            var x = (UserRoleModel)model;
            this.repository.Add(new UserRole(x.Id, x.RoleName));
        }

        /// <summary>
        /// Deletes a user role from the repository by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the user role to delete.</param>
        public void Delete(int modelId)
        {
            this.repository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all user roles from the repository.
        /// </summary>
        /// <returns>A collection of user role models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            return this.repository.GetAll().Select(x => new UserRoleModel(x.Id, x.RoleName));
        }

        /// <summary>
        /// Retrieves a user role by its ID.
        /// </summary>
        /// <param name="id">The ID of the user role to retrieve.</param>
        /// <returns>The user role model if found; otherwise, <c>null</c>.</returns>
        public AbstractModel GetById(int id)
        {
            var res = this.repository.GetById(id);

            if (res == null)
            {
                return null;
            }

            return new UserRoleModel(res.Id, res.RoleName);
        }

        /// <summary>
        /// Updates an existing user role in the repository.
        /// </summary>
        /// <param name="model">The user role model to update.</param>
        public void Update(AbstractModel model)
        {
            var x = (UserRoleModel)model;
            var userEntity = this.repository.GetById(x.Id);
            if (userEntity != null)
            {
                userEntity.Id = x.Id;
                userEntity.RoleName = x.RoleName;

                this.repository.Update(userEntity);
            }
        }

        /// <summary>
        /// Return count of the enteties in the specyfic DbSet.
        /// </summary>
        public int Count()
        {
            return this.repository.Count();
        }
    }
}
