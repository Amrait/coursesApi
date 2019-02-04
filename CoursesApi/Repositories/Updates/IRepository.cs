using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public interface IRepository <T>
    {
        bool Add(T entry);
        bool Remove(Guid id);
        T GetById(Guid id);
        bool Update(Guid id, T entry);
        IEnumerable<T> GetAll();
    }
}
