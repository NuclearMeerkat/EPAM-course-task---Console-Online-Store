namespace StoreBLL.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a user role in the system.
    /// </summary>
    public class UserRoleModel : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleModel"/> class with the specified ID and role name.
        /// </summary>
        /// <param name="id">The ID of the user role.</param>
        /// <param name="roleName">The name of the user role.</param>
        public UserRoleModel(int id, string? roleName)
            : base(id)
        {
            this.RoleName = roleName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleModel"/> class with the specified role name.
        /// </summary>
        /// <param name="roleName">The name of the user role.</param>
        public UserRoleModel(string roleName)
            : base(default)
        {
            this.RoleName = roleName;
        }

        /// <summary>
        /// Gets or sets the name of the user role.
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// Returns a string representation of the user role.
        /// </summary>
        /// <returns>A string that represents the user role.</returns>
        public override string ToString()
        {
            return $"Id:{this.Id} {this.RoleName}";
        }
    }
}
