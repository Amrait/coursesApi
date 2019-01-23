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
        private string _streetLine1;
        private string _streetLine2;
        private string _city;
        private string _state;
        private string _postalCode;
        private string _country;
        #endregion


        public int AddressType { get; set; }
        public string StreetLine1 { get => StreetLine1; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _streetLine1 = value;
                }
            }
        }
        public string StreetLine2 { get => StreetLine2;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _streetLine2 = value;
                }
            }
        }
        public string City
        { get => City;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _city = value;
                }
            }
        }
        public string State { get => State; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _state = value;
                }
            }
        }
        public string PostalCode { get => PostalCode; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _postalCode = value;
                }
            }
        }
        public string Country { get => Country;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _country = value;
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
