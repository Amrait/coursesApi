using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoursesApi.Models
{
    public class EntityBase
    {
        public Guid id;
        public string name;
        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.id}, name - {this.name}");
        }
        public bool Validate()
        {
            return string.IsNullOrWhiteSpace(this.name);
        }
    }
}