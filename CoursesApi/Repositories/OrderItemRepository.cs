using CoursesApi.Common.Utilities;
using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public class OrderItemRepository
    {
        public OrderItemRepository()
        {
            this.repository = new Dictionary<Guid, OrderItem>();
        }

        private Dictionary<Guid, OrderItem> repository;

        /// <summary>
        /// Adds specified order item to the backing repository. If order item is already
        /// present or malformed, won't add it.
        /// </summary>
        /// <param name="orderItem">Order to add</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Add(OrderItem orderItem)
        {
            bool success = true;
            var logger = new Logger();
            if (orderItem.Validate())
            {
                if (!repository.ContainsKey(orderItem.id))
                {
                    repository.Add(orderItem.id, orderItem);
                    logger.LogInfo("Order item with id {} was successfully added.", orderItem.id);
                }
                else
                {
                    logger.LogError("Order item with id {} is already in the repository.", orderItem.id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Order item is malformed");
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
                logger.LogInfo("Order item with id - {} was successfully removed", id);
            }
            else
            {
                logger.LogError("Order item with id - {} is not present in the repository.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Updates the entry found by specified ID
        /// </summary>
        /// <param name="id">ID of the entry</param>
        /// <param name="orderItem">Value to update with</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Update(Guid id, OrderItem orderItem)
        {
            bool success = true;
            var logger = new Logger();
            if (orderItem.Validate())
            {
                if (repository.ContainsKey(id))
                {
                    repository[id] = orderItem;
                    logger.LogInfo("Order item with id - {} was successfully updated", orderItem.id);
                }
                else
                {
                    logger.LogError("Order item with id - {} is not present in the repository.", id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Order item is malformed.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Get's an entry by id from the backing repository.
        /// </summary>
        /// <param name="id">ID of the desired entry</param>
        /// <returns>Entry</returns>
        public OrderItem GetById(Guid id)
        {
            OrderItem result = null;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                result = repository[id];
                logger.LogInfo("Order item with id - {} was successfully found.", id);
            }
            return result;
        }

        /// <summary>
        /// Gets the list of all entries.
        /// </summary>
        /// <returns>List of entries</returns>
        public List<OrderItem> GetAll()
        {
            return new List<OrderItem>(repository.Values);
        }
    }
}
