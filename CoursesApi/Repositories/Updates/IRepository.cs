using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public interface IRepository
    {
        bool Add(Object entry);
        bool Remove(Guid id);
        Object GetById(Guid id);
        bool Update(Guid id, Object entry);
        List<Object> GetAll();
    }
}
