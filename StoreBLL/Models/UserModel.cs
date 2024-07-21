namespace StoreBLL.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class UserModel : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class with specified parameters.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="name">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="login">The user's login name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="roleId">The user's role ID.</param>
        public UserModel(int id, string? name, string? lastName, string? login, string? password, int roleId)
            : base(id)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
            this.RoleId = roleId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class with specified parameters.
        /// </summary>
        /// <param name="name">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="login">The user's login name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="roleId">The user's role ID.</param>
        public UserModel(string? name, string? lastName, string? login, string? password, int roleId)
            : base(0)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
            this.RoleId = roleId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        public UserModel()
            : base(0)
        {
        }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's login name.
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the user's role ID.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the list of customer orders associated with the user.
        /// </summary>
        public List<CustomerOrderModel>? Orders { get; set; } // From Order entity

        /// <summary>
        /// Returns a string representation of the user.
        /// </summary>
        /// <returns>A string that represents the user.</returns>
        public override string? ToString()
        {
            return $"ID:{this.Id,-8} Name: {this.Name,-15} Last name: {this.LastName,-15} Login: {this.Login,-15}";
        }
    }
}
