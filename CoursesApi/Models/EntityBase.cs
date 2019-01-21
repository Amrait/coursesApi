using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoursesApi.Models
{
    public class EntityBase
    {
        public Guid Id;
        public string Name;
        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.Id}, name - {this.Name}");
        }
        public bool Validate()
        {
            return string.IsNullOrWhiteSpace(this.Name);
        }
    }
}