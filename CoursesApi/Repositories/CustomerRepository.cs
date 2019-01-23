using CoursesApi.Common.Utilities;
using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
            this.repository = new Dictionary<Guid, Customer>();
        }

        private Dictionary<Guid, Customer> repository;
        public bool Add(Customer customer)
        {
            bool success = true;
            var logger = new Logger();
            if (customer.Validate())
            {
                if (!repository.ContainsKey(customer.id))
                {
                    repository.Add(customer.id, customer);
                    logger.LogInfo("Customer with id {} was successfully added.", customer.id);
                }
                else
                {
                    logger.LogError("Customer with id {} is already in the repository.", customer.id);
                    success = false;
                }
            }
            else
            {
                logger.LogInfo("Customer is malformed");
                success = false;
            }
            return success;
        }

        public bool Delete(Guid id)
        {
            bool success = true;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                repository.Remove(id);
                logger.LogInfo("Customer with id {} was successfully removed from the repository.", id);
            }
            else
            {
                logger.LogError("Customer with id {} is not present in the repository.", id);
                success = false;
            }
            return success;
        }

        public bool Update(Customer customer)
        {
            bool success = true;
            var logger = new Logger();
            if (customer.Validate())
            {
                if (repository.ContainsKey(customer.id))
                {
                    repository[customer.id] = customer;
                    logger.LogInfo("Customer with id {} was successfully updated.");
                    success = true;
                }
                else
                {
                    logger.LogError("Customer with id {} is not present in the repository.");
                    success = false;
                }
            }
            else
            {
                logger.LogError("Customer is malformed");
                success = false;
            }
            return success;
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(repository.Values);
        }
    }
}
