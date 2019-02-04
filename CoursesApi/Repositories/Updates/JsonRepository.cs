using CoursesApi.Common.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories.Updates
{
    public class JsonRepository<T> : IRepository<T>
    {
        public JsonRepository(string logName)
        {
            this.logger = new Logger(logName);
        }

        private Logger logger;

        public bool Add(T entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public bool Update(Guid id, T entry)
        {
            throw new NotImplementedException();
        }
    }

    class JsonCollection<T>
    {
        JsonCollection()
        {
        }
        public Dictionary<string, T> content;
    }
}
