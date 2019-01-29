using CoursesApi.Common.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories.Updates
{
    public class JsonRepository : Repository
    {
        public string Serialize(object entry)
        {
            var logger = new Logger("result.json");
            string json = JsonConvert.SerializeObject(entry, Formatting.Indented);
            logger.LogJson(json);
            return json;
        }

        // Well, it make sense to DESERIALIZE, but there's no good point to do this
        // without generics
    }
}
