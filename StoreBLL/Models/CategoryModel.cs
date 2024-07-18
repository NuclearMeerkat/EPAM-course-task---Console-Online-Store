namespace StoreBLL.Models;
using StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

public class CategoryModel : AbstractModel
{
    public CategoryModel(int id, string name)
        : base(id)
    {
        this.CategoryName = name;
    }

    public CategoryModel(string name)
        : base(default)
    {
        this.CategoryName = name;
    }

    public string CategoryName { get; set; }

    public override string ToString()
    {
        return $"Category name: {this.CategoryName}";
    }
}
