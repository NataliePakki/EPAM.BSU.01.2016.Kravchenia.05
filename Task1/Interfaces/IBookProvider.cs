using System.Collections.Generic;

namespace Task1.Interfaces{
    public interface IBookProvider {
        void Load(out List<Book> books);
        void Save(List<Book> books);
    }
}
