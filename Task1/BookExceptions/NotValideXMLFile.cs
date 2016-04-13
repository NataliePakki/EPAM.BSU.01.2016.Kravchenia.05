using System;

namespace Task1.BookExceptions {
    public class NotValideXMLFile : Exception {
        public NotValideXMLFile() { }
        public NotValideXMLFile(string message) : base(message) { }
        public NotValideXMLFile(string message, Exception inner) : base(message, inner) { }
    }
}