using System;

namespace Task1.BookExceptions{
    public class BookAlreadyExistException:Exception{
    public BookAlreadyExistException() { }
    public BookAlreadyExistException(string message) : base(message) { }
    public BookAlreadyExistException(string message, Exception inner) : base(message, inner) { }
    }
    
}
