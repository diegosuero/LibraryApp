using System;
using System.Collections.Generic;

namespace Library.DataAccess.Interface
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Save();
        List<T> GetAll();
        void Remove(T value);
        void Update(T value);
        T Get(int id);
        T GetByToken(Guid guid);
    }
}
