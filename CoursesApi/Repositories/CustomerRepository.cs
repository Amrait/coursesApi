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

        /// <summary>
        /// Adds a customer to the repository. In case customer malformed or is already present,
        /// won't add it.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Success or failure of the operation</returns>
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

        /// <summary>
        /// Deletes by id if entry is present in the repository.
        /// </summary>
        /// <param name="id">ID of the entry to delete</param>
        /// <returns>Success or failure of the operation</returns>
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

        /// <summary>
        /// Updates an entry with specified ID by passed value.
        /// </summary>
        /// <param name="id">ID of the entry to update</param>
        /// <param name="customer">Value to update an entry with</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Update(Guid id, Customer customer)
        {
            bool success = true;
            var logger = new Logger();
            if (customer.Validate())
            {
                if (repository.ContainsKey(id))
                {
                    repository[id] = customer;
                    logger.LogInfo("Customer with id {} was successfully updated.", customer.id);
                    success = true;
                }
                else
                {
                    logger.LogError("Customer with id {} is not present in the repository.", id);
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

        public Customer GetById(Guid id)
        {
            Customer result = null;
            if (repository.ContainsKey(id))
            {
                result = repository[id];
            }
            return result;
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(repository.Values);
        }
    }
}
