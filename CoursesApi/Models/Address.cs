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
            base.Id = addressId;
        }

        private int AddressType;
        private string StreetLine1;
        private string StreetLine2;
        private string City;
        private string State;
        private string PostalCode;
        private string Country;

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Address Id - {base.Id}, country - {GetCountry()}, city - {GetCity()}");
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

        #region Getters / Setters
        public int GetAddressType()
        {
            return this.AddressType;
        }
        public void SetAddressType(int addressType)
        {
            this.AddressType = addressType;
        }

        public string GetStreetLine1()
        {
            return this.StreetLine1;
        }
        public bool SetStreetLine1(string streetLine1)
        {
            if (!String.IsNullOrWhiteSpace(streetLine1))
            {
                this.StreetLine1 = streetLine1;
                return true;
            }
            else return false;
        }

        public string GetStreetLine2()
        {
            return this.StreetLine2;
        }
        public bool SetStreetLine2(string streetLine2)
        {
            if (!String.IsNullOrWhiteSpace(streetLine2))
            {
                this.StreetLine2 = streetLine2;
                return true;
            }
            else return false;
        }

        public string GetCity()
        {
            return this.City;
        }
        public bool SetCity(string city)
        {
            if (!String.IsNullOrWhiteSpace(city))
            {
                this.City = city;
                return true;
            }
            else return false;
        }

        public string GetState()
        {
            return this.State;
        }
        public bool SetState(string state)
        {
            if (!String.IsNullOrWhiteSpace(state))
            {
                this.State = state;
                return true;
            }
            else return false;
        }

        public string GetPostalCode()
        {
            return this.PostalCode;
        }
        public bool SetPostalCode(string postalCode)
        {
            if (!String.IsNullOrWhiteSpace(postalCode))
            {
                this.PostalCode = postalCode;
                return true;
            }
            else return false;
        }

        public string GetCountry()
        {
            return this.Country;
        }
        public bool SetCountry(string country)
        {
            if (!String.IsNullOrWhiteSpace(country))
            {
                this.Country = country;
                return true;
            }
            else return false;
        }

        #endregion
    }
}
