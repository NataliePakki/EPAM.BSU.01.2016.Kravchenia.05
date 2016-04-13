using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NLog;
using Task1.BookExceptions;
using Task1.Interfaces;

namespace Task1 {
    public class BookXmlProvider : IBookProvider{
        private readonly FileInfo booksFile;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private const string  BooksDtd = @"<!ELEMENT Books (Book+)>    
                                <!ELEMENT Book (Name, Author, Price)>
                                <!ELEMENT Name (#PCDATA)>
                                <!ELEMENT Author (#PCDATA)>
                                <!ELEMENT Price (#PCDATA)>";
        public BookXmlProvider(FileInfo booksFile) {
            logger.Info("BookXmlProvider(): ");
            if (!booksFile.Exists) {
                logger.Fatal($"Could not find the books file {booksFile.FullName} to process.");
                throw new FileNotFoundException("Could not find the books file to process.");
            }
            this.booksFile = booksFile;
        }
        public List<Book> Load() {
            try {
                Validate();
                var xDocument = XDocument.Load(booksFile.FullName, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
                var Listbook = (from xml in xDocument.Elements("Books").Elements("Book")
                    select new Book(xml.Element("Name").Value,
                        xml.Element("Author").Value,
                        int.Parse(xml.Element("Price").Value)));

                logger.Info("All books were loaded.");
                return Listbook.ToList();
            }
            catch(XmlException ex) {
                logger.Error("Exception.Message: " + ex.Message);
                logger.Error("Load failed.");
                return new List<Book>();
            }
        }
        public void Save(List<Book> books) {
            var xDoc = new XDocument(new XDocumentType("Books", null, null, BooksDtd), new XElement("Books",
               books.Select(b =>
                   new XElement("Book",
                   new XElement("Name", b.Name),
                   new XElement("Author", b.Author),
                   new XElement("Price", b.Price)))));

            logger.Info("All books were saved.");
            xDoc.Save(booksFile.FullName);
        }

        private void Validate() {
            var r = new XmlTextReader(booksFile.FullName);
            var v = new XmlValidatingReader(r) {ValidationType = ValidationType.DTD};
            v.ValidationEventHandler += ValidationCallBack;
            while (v.Read());
        }
        private static void ValidationCallBack(object sender, ValidationEventArgs e) {
            logger.Fatal("XML File not correct.");
            throw new NotValideXMLFile("XML File not correct.");
        }
    }
}