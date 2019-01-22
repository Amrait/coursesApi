using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Models
{
    public class Customer : EntityBase
    {
        public Customer() : this(Guid.NewGuid(), string.Empty)
        {
        }

        public Customer(Guid customerId, string name)
        {
            base.id = customerId;
            base.name = name;
            this.AddressList = new List<Address>();
        }

        public List<Address> AddressList
        {
            get => AddressList;
            protected set
            {
                if (value != null)
                {
                    this.AddressList = value;
                }
            }
        }
        public int CustomerType { get; set; }
        public static int InstanceCount { get; private set; }
        public string LastName { get => LastName; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.LastName = value;
                }
            }
        }
        public string EmailAddress
        {
            get => EmailAddress;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.EmailAddress = value;
                }
            }
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Customer Id - {base.id}, first name - {base.name}, last name - {this.LastName}");
        }
        
        public new bool Validate()
        {
            return (String.IsNullOrWhiteSpace(LastName) && String.IsNullOrWhiteSpace(EmailAddress));
        }
    }
}
