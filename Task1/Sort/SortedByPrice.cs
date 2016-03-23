using System.Collections.Generic;

namespace Task1.Sort
{
    public class SortedByPrice:IComparer<Book> {
        public int Compare(Book b1, Book b2) {
            double price1 = b1.Price;
            double price2 = b2.Price;
            return price1.CompareTo(price2);
        }
    }
}
