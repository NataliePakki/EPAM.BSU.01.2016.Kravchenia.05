﻿using System;
using System.Collections.Generic;

namespace Task1.Interfaces{
    public interface IRepository<T> : IDisposable  {
        List<T> GetList(); 
        void Add(T item); 
        void Remove(string name);
        List<Book> FindAll(IEqualityComparer<T> comparer);
        List<Book> Sort(IComparer<T> comparer);
    }
}