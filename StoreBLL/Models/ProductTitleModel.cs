using StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLL.Models
{
    public class ProductTitleModel : AbstractModel
    {
        public ProductTitleModel(int id, string? title, int CategoryId)
            : base(id)
        {
            this.Title = title;
            this.CategoryId = CategoryId;
        }

        public ProductTitleModel() : base(0) { }

        public string? Title { get; set; }

        public int CategoryId { get; set; }

        public override string? ToString()
        {
            return $"Id:{this.Id} {this.Title} {this.CategoryId}";
        }
    }
}
