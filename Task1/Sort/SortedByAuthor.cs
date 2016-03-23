
using System;
using System.Collections.Generic;

namespace Task1.Sort
{
    public class SortedByAuthor: IComparer<Book> {
        public int Compare(Book b1, Book b2) {
            string a1 = b1.Author;
            string a2 = b2.Author;
            return a1.CompareTo(a2);
        }
    }
}
