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

        public int AddressType { get; set; }
        public string StreetLine1 { get => StreetLine1; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.StreetLine1 = value;
                }
            }
        }
        public string StreetLine2 { get => StreetLine2; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.StreetLine2 = value;
                }
            }
        }
        public string City { get => City; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.City = value;
                }
            }
        }
        public string State { get => State; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.State = value;
                }
            }
        }
        public string PostalCode { get => PostalCode; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.PostalCode = value;
                }
            }
        }
        public string Country { get => Country; set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.Country = value;
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
