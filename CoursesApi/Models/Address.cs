using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Models
{
    public class Address : EntityBase
    {
        public Address()
        {
        }

        public Address(Guid addressId)
        {
            base.id = addressId;
        }

        #region backing fields
        private string streetLine1;
        private string streetLine2;
        private string city;
        private string state;
        private string postalCode;
        private string country;
        #endregion

        public int AddressType { get; set; }
        public string StreetLine1
        {
            get => streetLine1;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    streetLine1 = value;
                }
            }
        }
        public string StreetLine2
        {
            get => streetLine2;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    streetLine2 = value;
                }
            }
        }
        public string City
        {
            get => city;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    city = value;
                }
            }
        }
        public string State
        {
            get => state;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    state = value;
                }
            }
        }
        public string PostalCode
        {
            get => postalCode;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    postalCode = value;
                }
            }
        }
        public string Country
        {
            get => country;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    country = value;
                }
            }
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Address Id - {base.id}, country - {Country}, city - {City}");
        }

        public new bool Validate()
        {
            // Once logger is available, these should be splitted to provide
            // informative messages about which fields are malformed
            return (String.IsNullOrWhiteSpace(Country) &&
                    String.IsNullOrWhiteSpace(State) &&
                    String.IsNullOrWhiteSpace(City) &&
                    String.IsNullOrWhiteSpace(StreetLine1) &&
                    String.IsNullOrWhiteSpace(StreetLine2));
        }
    }
}
