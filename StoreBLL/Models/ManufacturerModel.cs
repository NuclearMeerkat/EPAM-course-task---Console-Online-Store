namespace StoreBLL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using StoreDAL.Entities;

    /// <summary>
    /// Represents a model for a manufacturer.
    /// </summary>
    public class ManufacturerModel : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerModel"/> class with a specified ID and name.
        /// </summary>
        /// <param name="id">The ID of the manufacturer.</param>
        /// <param name="name">The name of the manufacturer.</param>
        public ManufacturerModel(int id, string name)
            : base(id)
        {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerModel"/> class with a specified name.
        /// </summary>
        /// <param name="name">The name of the manufacturer.</param>
        public ManufacturerModel(string name)
            : base(default)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the name of the manufacturer.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of products associated with the manufacturer.
        /// </summary>
        public virtual ICollection<Product>? Products { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"ID:{this.Id,-8} Name: {this.Name}";
        }
    }
}
