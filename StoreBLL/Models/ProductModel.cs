using StoreDAL.Entities;

namespace StoreBLL.Models;

public class ProductModel : AbstractModel
{
    public ProductModel(int id, int titleId, int manufacturerId, decimal unitPrice, string? description, ProductTitleModel productTitle, ManufacturerModel manufacturer)
        : base(id)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.UnitPrice = unitPrice;
        this.Description = description;
        this.Title = productTitle;
        this.Manufacturer = manufacturer;
    }

    public ProductModel(int titleId, int manufacturerId, decimal unitPrice, string? description, ProductTitleModel productTitle, ManufacturerModel manufacturer)
        : base(default)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.UnitPrice = unitPrice;
        this.Description = description;
        this.Title = productTitle;
        this.Manufacturer = manufacturer;
    }

    public ProductModel(int titleId, int manufacturerId, decimal unitPrice, string? description)
        : base(default)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.UnitPrice = unitPrice;
        this.Description = description;
    }

    public ProductModel(int id, int titleId, int manufacturerId, decimal unitPrice, string? description)
        : base(id)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.UnitPrice = unitPrice;
        this.Description = description;
    }

    public ProductModel()
        : base(0)
    {
    }

    public int TitleId { get; set; }

    public int ManufacturerId { get; set; }

    public decimal UnitPrice { get; set; }

    public string? Description { get; set; }

    public ProductTitleModel Title { get; set; }

    public ManufacturerModel Manufacturer { get; set; }

    public virtual IList<OrderDetail>? OrderDetails { get; set; }

    public override string? ToString()
    {
        return $"{"ID:" + this.Id,-7} {"Title:" + this.Description + " " + this.Title.Title,-25} {"Price:" + this.UnitPrice,-13} {"Manufacturer:" + this.Manufacturer.Name,-10}";
    }
}