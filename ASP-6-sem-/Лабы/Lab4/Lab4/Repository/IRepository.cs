using System;
using System.Collections.Generic;

namespace Lab4.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Remove(T item);
        void Update(T item);
    }
}
