using System;

namespace Task1.BookExceptions{
    public class BookExistException:Exception{
    public BookExistException() { }
    public BookExistException(string message) : base(message) { }
    public BookExistException(string message, Exception inner) : base(message, inner) { }
    }
    
}
