using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NLog;
using Task1.Interfaces;

namespace Task1 {
    public class BookXmlProvider : IBookProvider{
        private readonly FileInfo booksFile;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public BookXmlProvider(FileInfo booksFile) {
            logger.Info("BookXmlProvider(): ");
            if (!booksFile.Exists) {
                logger.Fatal($"Could not find the books file {booksFile.FullName} to process.");
                throw new FileNotFoundException("Could not find the books file to process.");
            }
            this.booksFile = booksFile;
        }
        public List<Book> Load() {
                var xDocument = XDocument.Load(booksFile.FullName, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
                var Listbook = (from xml in xDocument.Elements("Books").Elements("Book")
                                select new Book(xml.Element("Name").Value,
                                    xml.Element("Author").Value,
                                    int.Parse(xml.Element("Price").Value))
                                );
                logger.Info("All books were loaded.");
                return Listbook.ToList();
         }
        public void Save(List<Book> books) {
            var xDoc = new XElement("Books",
               books.Select(b =>
                   new XElement("Book",
                   new XElement("Name", b.Name),
                   new XElement("Author", b.Author),
                   new XElement("Price", b.Price))));

            logger.Info("All books were saved.");
            xDoc.Save(booksFile.FullName);
        }
    }
}