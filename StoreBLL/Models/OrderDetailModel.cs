using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        public OrderDetailModel(int id, int ProductId,  decimal Price, int Amount, int CustomerOrderId)
        : base(id)
        {
            this.ProductId = ProductId;
            this.Price = Price;
            this.Amount = Amount;
            this.CustomerOrderId = CustomerOrderId;
        }

        public OrderDetailModel(int ProductId, decimal Price, int Amount, int CustomerOrderId)
        : base(0)
        {
            this.ProductId = ProductId;
            this.Price = Price;
            this.Amount = Amount;
            this.CustomerOrderId = CustomerOrderId;
        }

        public OrderDetailModel() : base(0) { }

        public int CustomerOrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public override string? ToString()
        {
            return $"{"ID:" + this.Id,-7} {"ProductID:" + this.ProductId,-15} {"Price:" + this.Price,-8} {"Amount:" + this.Amount,-10}";
        }
    }
}
