using System;
using System.Collections.Generic;
using System.Text;
using CoursesApi.Common.Utilities;
using CoursesApi.Models;

namespace CoursesApi.Repositories
{
    public class Repository : IRepository
    {
        public Repository()
        {
            this.repository = new Dictionary<Guid, object>();
        }

        private Dictionary<Guid, object> repository;

        public bool Add(object entry)
        {
            EntityBase castedEntry = entry as EntityBase;
            bool success = true;
            var logger = new Logger();
            if (castedEntry.Validate())
            {
                if (!repository.ContainsKey(castedEntry.id))
                {
                    repository.Add(castedEntry.id, entry);
                    logger.LogInfo("Entry with id {} was successfully added.", castedEntry.id);
                }
                else
                {
                    logger.LogError("Entry with id {} is already in the repository.", castedEntry.id);
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

        public List<object> GetAll()
        {
            return new List<object>(repository.Values);
        }

        public object GetById(Guid id)
        {
            object result = null;
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

        public bool Update(Guid id, object entry)
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
