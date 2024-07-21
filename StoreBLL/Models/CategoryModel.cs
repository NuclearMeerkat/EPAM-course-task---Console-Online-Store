namespace StoreBLL.Models;

using StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Represents a category model.
/// </summary>
public class CategoryModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryModel"/> class.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <param name="name">The name of the category.</param>
    public CategoryModel(int id, string name)
        : base(id)
    {
        this.CategoryName = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryModel"/> class.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    public CategoryModel(string name)
        : base(default)
    {
        this.CategoryName = name;
    }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Returns a string representation of the category model.
    /// </summary>
    /// <returns>A string that represents the category model.</returns>
    public override string ToString()
    {
        return $"ID:{this.Id,-8} Category name: {this.CategoryName}";
    }
}
