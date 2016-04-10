using System.Collections.Generic;
using System.IO;
using NLog;
using Task1.Interfaces;

namespace Task1 {
    public class BookFileProvider : IBookProvider {
        private readonly FileInfo booksFile;
        private BinaryReader reader;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public BookFileProvider(FileInfo booksFile) {
            logger.Info("BookFileProvider(): ");
            if (!booksFile.Exists) {
                logger.Fatal($"Could not find the books file {booksFile.FullName} to process.");
                throw new FileNotFoundException("Could not find the books file to process.");
            }
            this.booksFile = booksFile;
        }
        public List<Book> Load() {
            logger.Info($"Load books from {booksFile.Name}: ");
            var books = new List<Book>();
            using (reader = new BinaryReader(File.Open(booksFile.FullName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1){
                    string name = reader.ReadString();
                    string author = reader.ReadString();
                    int price = reader.ReadInt32();
                    books.Add(new Book(name, author, price));
                    logger.Info($"Book: NAME: {name}, AUTHOR: {author}, PRICE: {price} was loaded.");
                }
            }
            
            logger.Info("All books were loaded.");
            return books;

        }
        public void Save(List<Book> books){
            logger.Info($"Save books in {booksFile.Name}.");
            File.Delete(booksFile.FullName);
            using (var writer = new BinaryWriter(File.Open(booksFile.FullName, FileMode.OpenOrCreate))) {
                foreach (Book b in books){
                    writer.Write(b.Name);
                    writer.Write(b.Author);
                    writer.Write(b.Price);
                    logger.Info($"Book: NAME: {b.Name}, AUTHOR: {b.Author}, PRICE: {b.Price} was saved.");
                }
            }
            logger.Info("All books were saved.");
        }
    }
}
