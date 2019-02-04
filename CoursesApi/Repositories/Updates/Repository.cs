using System;
using System.Collections.Generic;
using System.Text;
using CoursesApi.Common.Utilities;
using CoursesApi.Models;

namespace CoursesApi.Repositories
{
    public class EntityRepository<T> : IRepository<T> where T : EntityBase
    {
        public EntityRepository()
        {
            this.repository = new Dictionary<Guid, T>();
        }

        private Dictionary<Guid, T> repository;

        public bool Add(T entry)
        {
            bool success = true;
            var logger = new Logger();
            if (entry.Validate())
            {
                if (!repository.ContainsKey(entry.id))
                {
                    repository.Add(entry.id, entry);
                    logger.LogInfo("Entry with id {} was successfully added.", entry.id);
                }
                else
                {
                    logger.LogError("Entry with id {} is already in the repository.", entry.id);
                    success = false;
                }
            }
            else
            {
                logger.LogError("Entry is malformed.");
                success = false;
            }
            return success;
        }

        public IEnumerable<T> GetAll()
        {
            return repository.Values;
        }

        public T GetById(Guid id)
        {
            T result = default(T);
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                result = repository[id];
                logger.LogInfo("Entry with id - {} was successfully found.", id);
            }
            else
            {
                logger.LogInfo("Entry with id - {} was not found.", id);
            }
            return result;
        }

        public bool Remove(Guid id)
        {
            bool success = true;
            var logger = new Logger();
            if (repository.ContainsKey(id))
            {
                repository.Remove(id);
                logger.LogInfo("Entry with id - {} was successfully removed", id);
            }
            else
            {
                logger.LogError("Entry with id - {} is not present in the repository.");
                success = false;
            }
            return success;
        }

        public bool Update(Guid id, T entry)
        {
            EntityBase castedEntry = entry as EntityBase;
            bool success = true;
            var logger = new Logger();
            if (castedEntry.Validate())
            {
                if (repository.ContainsKey(id))
                {
                    repository[id] = entry;
                    logger.LogInfo("Entry with id - {} was successfully updated", castedEntry.id);
                }
                else
                {
                    logger.LogError("Entry with id - {} is not present in the repository.");
                    success = false;
                }
            }
            else
            {
                logger.LogError("Entry is malformed.");
                success = false;
            }
            return success;
        }
    }
}
