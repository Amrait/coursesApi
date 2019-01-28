using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoursesApi.Models
{
    public abstract class EntityBase
    {
        public Guid id;
        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.id}");
        }
        public abstract bool Validate();
    }
}