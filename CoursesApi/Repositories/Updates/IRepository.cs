using CoursesApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApi.Repositories
{
    public interface IRepository
    {
        bool Add(EntityBase entry);
        bool Remove(Guid id);
        EntityBase GetById(Guid id);
        bool Update(Guid id, EntityBase entry);
        List<EntityBase> GetAll();
    }
}
