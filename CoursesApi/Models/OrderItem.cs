using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Models
{
    public class OrderItem : EntityBase
    {
        public OrderItem(Guid id, Product product, int quantity) {
            base.id = id;
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product
        {
            get => Product;
            protected set
            {
                if (value != null)
                {
                    this.Product = value;
                }
            }
        }
        public int Quantity
        {
            get => Quantity;
            set
            {
                if (value > 0)
                    this.Quantity = value;
            }
        }
        public decimal PurchasePrice {
            get {
                return this.Product.CurrentPrice * this.Quantity;
            }
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Order Item Id - {base.id}, " +
                $"product - {this.Product.ProductName}, quantity - {this.Quantity}");
        }

        public override bool Validate()
        {
            bool isValid = true;
            if (base.id == null)
            {
                isValid = false;
            }
            if (this.Product == null)
            {
                isValid = false;
            }
            if (this.Quantity <= 0)
            {
                isValid = false;
            }
            return isValid;
        }


    }
}
