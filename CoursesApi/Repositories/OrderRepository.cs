﻿using CoursesApi.Common.Utilities;
using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public class OrderRepository
    {
        public OrderRepository()
        {
            this.repository = new Dictionary<Guid, Order>();
        }

        private Dictionary<Guid, Order> repository;

        /// <summary>
        /// Adds specified order to the backing repository. If order is already
        /// present or malformed, won't add it.
        /// </summary>
        /// <param name="order">Order to add</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Add(Order order)
        {
            bool success = true;
            var logger = new Logger();
            if (order.Validate())
            {
                if (!repository.ContainsKey(order.id))
                {
                    repository.Add(order.id, order);
                    logger.LogInfo("Order with id {} was successfully added.", order.id);
                }
                else
                {
                    logger.LogError("Order with id {} is already in the repository.", order.id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Order is malformed");
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
                logger.LogInfo("Order with id - {} was successfully removed", id);
            }
            else
            {
                logger.LogError("Order with id - {} is not present in the repository.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Updates the entry found by specified ID
        /// </summary>
        /// <param name="id">ID of the entry</param>
        /// <param name="order">Value to update with</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Update(Guid id, Order order)
        {
            bool success = true;
            var logger = new Logger();
            if (order.Validate())
            {
                if (repository.ContainsKey(id))
                {
                    repository[id] = order;
                    logger.LogInfo("Order with id - {} was successfully updated", order.id);
                }
                else
                {
                    logger.LogError("Order with id - {} is not present in the repository.", id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Order is malformed.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Get's an entry by id from the backing repository.
        /// </summary>
        /// <param name="id">ID of the desired entry</param>
        /// <returns>Entry</returns>
        public Order GetById(Guid id)
        {
            Order result = null;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                result = repository[id];
                logger.LogInfo("Order with id - {} was successfully found.", id);
            }
            return result;
        }

        /// <summary>
        /// Gets the list of all entries.
        /// </summary>
        /// <returns>List of entries</returns>
        public List<Order> GetAll()
        {
            return new List<Order>(repository.Values);
        }
    }
}
