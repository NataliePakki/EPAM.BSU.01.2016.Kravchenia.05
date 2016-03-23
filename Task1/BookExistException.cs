using System;

namespace Task1
{
    public class BookExistException:Exception{
    public BookExistException() : base() { }
    public BookExistException(string message) : base(message) { }
    public BookExistException(string message, System.Exception inner) : base(message, inner) { }
    protected BookExistException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }
    
}
