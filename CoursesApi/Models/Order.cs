using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Models
{
    public class Order : EntityBase
    {
        #region backing fields
        private string orderName;
        #endregion
        public Customer Customer { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public Address ShippingAddress { get; protected set; }
        public List<OrderItem> OrderItems { get; protected set; }
        public string OrderName
        {
            get => orderName;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.orderName = value;
                }
            }
        }

        public Order() : this(Guid.NewGuid(), string.Empty)
        {
        }

        public Order(Guid orderId, string orderName)
        {
            base.id = orderId;
            this.orderName = orderName;
        }

        public Order(Guid orderId, string orderName, Customer customer, DateTime orderDate, Address shippingAddress)
        {
            base.id = orderId;
            this.orderName = orderName;
            this.Customer = customer;
            this.OrderDate = orderDate;
            this.ShippingAddress = shippingAddress;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Order Id - {base.id}, order name - {this.orderName}, " +
                $"order customer - {Customer.LastName}, order date - {OrderDate.ToShortDateString()}");
        }

        public override bool Validate()
        {
            bool isValid = true;
            if (Customer == null)
            {
                isValid = false;
            }
            if (OrderDate == null)
            {
                isValid = false;
            }
            if (ShippingAddress == null)
            {
                isValid = false;
            }
            if (OrderItems.Count == 0)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
