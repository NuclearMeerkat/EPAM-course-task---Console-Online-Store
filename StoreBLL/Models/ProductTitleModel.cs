namespace StoreBLL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoreDAL.Entities;

    public class ProductTitleModel : AbstractModel
    {
        public ProductTitleModel(int id, string? title, int CategoryId, CategoryModel category)
            : base(id)
        {
            this.Title = title;
            this.CategoryId = CategoryId;
            this.Category = category;
        }

        public ProductTitleModel(int id, string? title, int CategoryId)
            : base(id)
        {
            this.Title = title;
            this.CategoryId = CategoryId;
        }

        public ProductTitleModel(string? title, int categoryId)
            : base(default)
        {
            this.Title = title;
            this.CategoryId = categoryId;
        }

        public ProductTitleModel() : base(0)
        {
        }

        public string? Title { get; set; }

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }

        public override string? ToString()
        {
            return $"ID: {this.Id} \t Title: {this.Title} \t Category: {this.Category.CategoryName}\t";
        }
    }
}
