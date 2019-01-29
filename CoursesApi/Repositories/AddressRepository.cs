using CoursesApi.Common.Utilities;
using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public class AddressRepository
    {
        public AddressRepository()
        {
            this.repository = new Dictionary<Guid, Address>();
        }

        private Dictionary<Guid, Address> repository;

        /// <summary>
        /// Adds specified address to the backing repository. If address is already
        /// present or malformed, won't add it.
        /// </summary>
        /// <param name="address">Address to add</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Add(Address address)
        {
            bool success = true;
            var logger = new Logger();
            if (address.Validate())
            {
                if (!repository.ContainsKey(address.id))
                {
                    repository.Add(address.id, address);
                    logger.LogInfo("Address with id {} was successfully added.", address.id);
                }
                else
                {
                    logger.LogError("Address with id {} is already in the repository.", address.id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Address is malformed");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Deletes the entry if it is present in the backing repository.
        /// </summary>
        /// <param name="id">ID of the entry</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Delete(Guid id)
        {
            bool success = true;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                repository.Remove(id);
                logger.LogInfo("Address with id - {} was successfully removed", id);
            }
            else
            {
                logger.LogError("Address with id - {} is not present in the repository.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Updates the entry found by specified ID
        /// </summary>
        /// <param name="id">ID of the entry</param>
        /// <param name="address">Value to update with</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Update(Guid id, Address address)
        {
            bool success = true;
            var logger = new Logger();
            if (address.Validate())
            {
                if (repository.ContainsKey(id))
                {
                    repository[id] = address;
                    logger.LogInfo("Address with id - {} was successfully updated", address.id);
                }
                else
                {
                    logger.LogError("Address with id - {} is not present in the repository.");
                    success = false;
                }
            }
            else
            {
                logger.LogError("Address is malformed.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Get's an entry by id from the backing repository.
        /// </summary>
        /// <param name="id">ID of the desired entry</param>
        /// <returns>Entry</returns>
        public Address GetById(Guid id)
        {
            Address result = null;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                result = repository[id];
                logger.LogInfo("Address with id - {} was successfully found.", id);
            }
            return result;
        }

        /// <summary>
        /// Gets the list of all entries.
        /// </summary>
        /// <returns>List of entries</returns>
        public List<Address> GetAll()
        {
            return new List<Address>(repository.Values);
        }
    }
    
}
