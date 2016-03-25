using System.Collections.Generic;

namespace Task1.Interfaces{
    public interface IBookProvider {
        List<Book> Load();
        void Save(List<Book> books);
    }
}
