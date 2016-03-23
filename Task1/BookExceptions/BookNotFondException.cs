using System;

namespace Task1.BookExceptions{
    public class BookNotFondException: Exception{
    public BookNotFondException(){ }
    public BookNotFondException(string message) : base(message) { }
    public BookNotFondException(string message, System.Exception inner) : base(message, inner) { }
    }
}
