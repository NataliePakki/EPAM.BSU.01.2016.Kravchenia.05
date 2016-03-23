using System;
using System.Collections.Generic;

namespace Task1{
    public interface IBookRepository : IDisposable {
        List<Book> GetBookList(); 
        void AddBook(Book item); 
        void RemoveBook(string id);
        List<Book> FindAll(IEqualityComparer<Book> comparer);
        List<Book> SortBooks(IComparer<Book> comparer);
        void Load();
        void Save(); 
    }
}
