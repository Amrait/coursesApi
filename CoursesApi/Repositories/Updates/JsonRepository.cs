using CoursesApi.Common.Utilities;
using CoursesApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoursesApi.Repositories.Updates
{
    public class JsonRepository<T> : IRepository<T> where T : EntityBase
    {
        public JsonRepository(string logName, string jsonFile)
        {
            this.logger = new Logger(logName);
            this.jsonFile = jsonFile;
            this.cashedData = new JsonCollection<T>();
        }

        private Logger logger;
        private string jsonFile;
        private JsonCollection<T> cashedData;

        public bool Add(T entry)
        {
            bool success = true;
            if (entry.Validate())
            {

                if (!cashedData.cash.ContainsKey(entry.id))
                {
                    cashedData.cash.Add(entry.id, entry);
                }
                this.SerializeToFile();
                this.UpdateCash();
                foreach (var item in cashedData.cash)
                {
                    Console.WriteLine(item);
                }
                //if (!cash.cash.ContainsKey(entry.id))
                //{
                //    repository.Add(entry.id, entry);
                //    logger.LogInfo("Entry with id {} was successfully added.", entry.id);
                //}
                //else
                //{
                //    logger.LogError("Entry with id {} is already in the repository.", entry.id);
                //    success = false;
                //}
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

        private void UpdateCash()
        {
            using (StreamReader file = File.OpenText(jsonFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                var result = (JsonCollection<T>)serializer.Deserialize(file, typeof(JsonCollection<T>));
                // In theory, this is just a small check that should help in case of collection wipe,
                if (result != null)
                {
                    this.cashedData = result;
                }
            }
        }

        private void SerializeToFile()
        {
            string json = this.Serialize();
            File.WriteAllText(this.jsonFile, json);
        }

        private string Serialize()
        {
            return JsonConvert.SerializeObject(this.cashedData.cash, Formatting.Indented);
        }
    }

    class JsonCollection<T>
    {
        public JsonCollection()
        {
            cash = new Dictionary<Guid, T>();
        }

        public Dictionary<Guid, T> cash;
    }
}
