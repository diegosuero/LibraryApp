using System.Collections.Generic;

namespace Library.BusinessLogic.Interface
{
    public interface ILogic<T>
    {
        T Create(T entity);
        T Get(int id);
        List<T> GetAll();
        T Update(int id, T entity);
        void Delete (T entity);
    }
}