﻿using CoursesApi.Common.Utilities;
using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public class ProductRepository
    {
        public ProductRepository()
        {
            this.repository = new Dictionary<Guid, Product>();
        }

        private Dictionary<Guid, Product> repository;

        /// <summary>
        /// Adds specified product to the backing repository. If product is already
        /// present or malformed, won't add it.
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Add(Product product)
        {
            bool success = true;
            var logger = new Logger();
            if (product.Validate())
            {
                if (!repository.ContainsKey(product.id))
                {
                    repository.Add(product.id, product);
                    logger.LogInfo("Product with id {} was successfully added.", product.id);
                }
                else
                {
                    logger.LogError("Product with id {} is already in the repository.", product.id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Product is malformed");
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
                logger.LogInfo("Product with id - {} was successfully removed", id);
            }
            else
            {
                logger.LogError("Product with id - {} is not present in the repository.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Updates the entry found by specified ID
        /// </summary>
        /// <param name="id">ID of the entry</param>
        /// <param name="product">Value to update with</param>
        /// <returns>Success or failure of the operation</returns>
        public bool Update(Guid id, Product product)
        {
            bool success = true;
            var logger = new Logger();
            if (product.Validate())
            {
                if (repository.ContainsKey(id))
                {
                    repository[id] = product;
                    logger.LogInfo("Product with id - {} was successfully updated", product.id);
                }
                else
                {
                    logger.LogError("Product with id - {} is not present in the repository.", id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Product is malformed.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Get's an entry by id from the backing repository.
        /// </summary>
        /// <param name="id">ID of the desired entry</param>
        /// <returns>Entry</returns>
        public Product GetById(Guid id)
        {
            Product result = null;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                result = repository[id];
                logger.LogInfo("Product with id - {} was successfully found.", id);
            }
            return result;
        }

        /// <summary>
        /// Gets the list of all entries.
        /// </summary>
        /// <returns>List of entries</returns>
        public List<Product> GetAll()
        {
            return new List<Product>(repository.Values);
        }
    }
}
