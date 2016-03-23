using System;
using System.Collections.Generic;

namespace Task1.Interfaces{
    public interface IRepository<T> : IDisposable  {
        List<T> GetList(); 
        void Add(T item); 
        void Remove(T item);
        List<Book> FindAll(IEqualityComparer<T> comparer);
        void Sort(IComparer<T> comparer);
    }
}
