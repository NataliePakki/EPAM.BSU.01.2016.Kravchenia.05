using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NLog;
using Task1.Interfaces;

namespace Task1 {
    public class BookSerializeFileProvider : IBookProvider {
        private readonly FileInfo booksFile;
        private BinaryFormatter formatter;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public BookSerializeFileProvider(FileInfo booksFile) {
            logger.Info("BookFileProvider(): ");
            if (!booksFile.Exists) {
                logger.Fatal($"Could not find the books file {booksFile.FullName} to process.");
                throw new FileNotFoundException("Could not find the books file to process.");
            }
            this.booksFile = booksFile;
            this.formatter = new BinaryFormatter(); ;
        }
        public List<Book> Load() {
            logger.Info($"Load books from {booksFile.Name}: ");
            var books = new List<Book>();
            using (var fStream = File.OpenRead(booksFile.FullName)) {
                if(fStream.Length != 0)
                    books = (List<Book>)formatter.Deserialize(fStream);
            }
            logger.Info("All books were loaded.");
            return books;

        }
        public void Save(List<Book> books) {
            logger.Info($"Save books in {booksFile.Name}.");
            using (var fStream =  new FileStream(booksFile.FullName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                formatter.Serialize(fStream, books);
            }
           
            logger.Info("All books were saved.");
        }
    }
}
