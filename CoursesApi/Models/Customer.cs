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
            base.Id = customerId;
            base.Name = name;
            this.AddressList = new List<Address>();
        }

        private List<Address> AddressList;
        private int CustomerType;
        public static int InstanceCount;
        private string LastName;
        private string EmailAddress;

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Customer Id - {base.Id}, first name - {base.Name}, last name - {this.LastName}");
        }
        
        public new bool Validate()
        {
            return (String.IsNullOrWhiteSpace(LastName) && String.IsNullOrWhiteSpace(EmailAddress));
        }

        #region Getters / Setters
        public List<Address> GetAddresses()
        {
            return this.AddressList;
        }

        public bool AddAddress(Address address)
        {
            if (address.Validate())
            {
                AddressList.Add(address);
                return true;
            }
            else return false;
        }

        public int GetCustomerType()
        {
            return this.CustomerType;
        }

        public void SetCustomerType(int customerType)
        {
            this.CustomerType = customerType;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public bool SetLastName(string lastName)
        {
            if (!String.IsNullOrWhiteSpace(lastName))
            {
                this.LastName = lastName;
                return true;
            }
            else return false;
        }

        public string GetEmailAddress()
        {
            return this.EmailAddress;
        }

        public bool SetEmailAddress(string emailAddress)
        {
            if (!String.IsNullOrWhiteSpace(emailAddress))
            {
                this.EmailAddress = emailAddress;
                return true;
            }
            else return false;
        }
        #endregion
    }
}
