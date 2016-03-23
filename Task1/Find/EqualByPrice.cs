using System.Collections.Generic;

namespace Task1.Find {
    public class EqualByPrice : IEqualityComparer<Book>{
        public bool Equals(Book x, Book y) {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null) ) return false;
            return x.Price == y.Price;
        }

        public int GetHashCode(Book obj) {
            return obj.Price;
        }
    }
}
