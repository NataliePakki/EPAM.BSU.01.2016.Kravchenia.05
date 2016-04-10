using System;

namespace Task1 {
    [Serializable]
    public class Book : IEquatable<Book>{
        public Book() { }
        public Book(string name, string author, int price) {
        Name = name;
        Author = author;
        Price = price;
    }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }


     public override string ToString() {
        return $"NAME: {Name}, AUTHOR: {Author}, PRICE: {Price}.";
    }
     public bool Equals(Book other) {
         if (ReferenceEquals(null, other)) return false;
         if (ReferenceEquals(this, other)) return true;
         return string.Equals(Name, other.Name) && string.Equals(Author, other.Author) && Price == other.Price;
     }

    public override bool Equals(object obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Book) obj);
    }

    public override int GetHashCode(){
        unchecked{
            int hashCode = Name?.GetHashCode() ?? 0;
            hashCode = (hashCode * 397) ^ (Author?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ Price;
            return hashCode;
        }
    }

}
}
