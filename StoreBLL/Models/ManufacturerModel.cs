namespace StoreBLL.Models;
using StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

public class ManufacturerModel : AbstractModel
{
    public ManufacturerModel(int id, string name)
        : base(id)
    {
        Name = name;
    }

    public string? Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    public override string ToString()
    {
        return $"ID:{this.Id,-8} Name: {this.Name}";
    }
}
