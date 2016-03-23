using System.Collections.Generic;

namespace Task1.Sort
{
    public class SortedByName: Comparer<Book> {
        public override int Compare(Book b1, Book b2) {
                string name1 = b1.Name;
                string name2 = b2.Name;
                return name1.CompareTo(name2);

        }
    }
}
