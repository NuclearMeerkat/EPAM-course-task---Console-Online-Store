using StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLL.Models
{
    public class OrderDetailModel : AbstractModel
    {
        public OrderDetailModel(int id, int ProductId,  decimal Price, int Amount)
        : base(id)
        {
            this.ProductId = ProductId;
            this.Price = Price;
            this.Amount = Amount;
        }

        public OrderDetailModel() : base(0) { }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public override string? ToString()
        {
            return $"Price: {this.Price} Product amount: {this.Amount}";
        }
    }
}
