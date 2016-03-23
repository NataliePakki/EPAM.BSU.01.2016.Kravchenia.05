using System.Collections.Generic;
using System.IO;
using Task1.Interfaces;

namespace Task1 {
    class BookFileProvider : IBookProvider {
        private readonly FileInfo booksFile;
        private BinaryReader reader;
        public BookFileProvider(FileInfo booksFile) {
            if (!booksFile.Exists)
                throw new FileNotFoundException("Could not find the books file to process.");
            this.booksFile = booksFile;
        }
        public void Load(out List<Book> books) {
            books = new List<Book>();
            using (reader = new BinaryReader(File.Open(booksFile.FullName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1){
                    string name = reader.ReadString();
                    string author = reader.ReadString();
                    int price = reader.ReadInt32();
                    books.Add(new Book(name, author, price));
                }
            }

        }
        public void Save(List<Book> books){
            File.Delete(booksFile.FullName);
            using (var writer = new BinaryWriter(File.Open(booksFile.FullName, FileMode.OpenOrCreate)))
            {
                foreach (Book b in books){
                    writer.Write(b.Name);
                    writer.Write(b.Author);
                    writer.Write(b.Price);
                }
            }
        }
    }
}
