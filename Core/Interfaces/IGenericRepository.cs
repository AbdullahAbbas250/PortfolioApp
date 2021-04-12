using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IGenericRepository<Type> where Type : class
    {
        IEnumerable<Type> GetAll();
        Type GetById(object Id);
        void Insert(Type Entity);
        void Update(Type Entity);
        void Delete(Type Entity);
    }
}
