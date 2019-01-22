using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Models
{
    public class Order : EntityBase
    {
        public Customer Customer { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public Address ShippingAddress { get; protected set; }
        public List<OrderItem> OrderItems { get; protected set; }

        public Order() : this(Guid.NewGuid(), string.Empty)
        {
        }

        public Order(Guid orderId, string orderName)
        {
            base.id = orderId;
            base.name = orderName;
        }

        public Order(Guid orderId, string orderName, Customer customer, DateTime orderDate, Address shippingAddress)
        {
            base.id = orderId;
            base.name = orderName;
            this.Customer = customer;
            this.OrderDate = orderDate;
            this.ShippingAddress = shippingAddress;
        }
    }
}
