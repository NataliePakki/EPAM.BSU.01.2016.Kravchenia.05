
using System.Collections.Generic;

namespace Task1.Find {
    public class EqualByName : IEqualityComparer<Book> {
        public bool Equals(Book x, Book y) {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Name.Equals(y.Name);
        }
        public int GetHashCode(Book obj) {
            return obj.Name.GetHashCode();
        }
    }
}
