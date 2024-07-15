using Microsoft.VisualStudio.TextTemplating;
using StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreBLL.Models;

public class ProductModel : AbstractModel
{
    public ProductModel(int id, int titleId, int manufacturerId, decimal unitPrice, string? description, IList<OrderDetail>? orderDetails, ProductTitle productTitle, Manufacturer manufacturer)
        : base(id)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.UnitPrice = unitPrice;
        this.Description = description;
        this.OrderDetails = orderDetails;
        this.ProductTitle = productTitle;
    }

    public ProductModel() : base(0) { }

    public int TitleId { get; set; }

    public int ManufacturerId { get; set; }

    public decimal UnitPrice { get; set; }

    public string? Description { get; set; }

    public ProductTitle ProductTitle { get; set; }

    public Manufacturer Manufacturer {get; set;}

    public virtual IList<OrderDetail>? OrderDetails { get; set; }

    public override string? ToString()
    {
        return $"ID:{Id} Price:{UnitPrice} Title:{ProductTitle.Title} Manufacturer:{Manufacturer.Name} Description:{Description} ";
    }
}