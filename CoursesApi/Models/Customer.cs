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
        #region Backing fields
        private List<Address> addressList;
        private int customerType;
        private string lastName;
        private string emailAddress;
        #endregion

        public List<Address> AddressList
        {
            get => addressList;
            protected set
            {
                if (value != null)
                {
                    addressList = value;
                }
            }
        }
        public int CustomerType { get; set; }
        public static int InstanceCount { get; private set; }
        public string LastName
        {
            get => lastName;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }
        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    emailAddress = value;
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
