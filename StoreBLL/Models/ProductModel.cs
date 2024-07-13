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
    public ProductModel(int id, int titleId, int manufacturerId, decimal unitPrice, string? description, IList<OrderDetail>? orderDetails)
        : base(id)
    {
        TitleId = titleId;
        ManufacturerId = manufacturerId;
        UnitPrice = unitPrice;
        Description = description;
        OrderDetails = orderDetails;
    }

    public ProductModel() : base(0) { }

    public int TitleId { get; set; }

    public int ManufacturerId { get; set; }

    public decimal UnitPrice { get; set; }

    public string? Description { get; set; }

    public virtual IList<OrderDetail>? OrderDetails { get; set; }
}