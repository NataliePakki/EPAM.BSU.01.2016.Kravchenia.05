using System.Collections.Generic;

namespace Task1.Find {
    public class EqualByAuthor : IEqualityComparer<Book> {
        public bool Equals(Book x, Book y) {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Author.Equals(y.Author);
        }
        public int GetHashCode(Book obj) {
            return obj.Author.GetHashCode();
        }
    }
}
