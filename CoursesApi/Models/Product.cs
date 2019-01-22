using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Models
{
    public class Product : EntityBase
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }

        public Product() : this(Guid.NewGuid(), string.Empty)
        {
        }

        public Product(Guid productId, string productName)
        {
            base.id = productId;
            this.ProductName = productName;
        }

        public Product(Guid productId, string productName, string description)
        {
            base.id = productId;
            this.ProductName = productName;
            this.Description = description;
        }

        public Product(Guid productId, string productName, string description, decimal currentPrice)
        {
            base.id = productId;
            this.ProductName = productName;
            this.Description = description;
            this.CurrentPrice = currentPrice;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Product Id - {base.id}, product name - {this.ProductName}");
        }

        public new bool Validate()
        {
            // Once logger is here, this will be logged properly
            bool isValid = true;
            if (!String.IsNullOrWhiteSpace(this.ProductName))
            {
                isValid = false;
            }
            if (base.id == null)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
