using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookNotFindException: Exception{
    public BookNotFindException() : base() { }
    public BookNotFindException(string message) : base(message) { }
    public BookNotFindException(string message, System.Exception inner) : base(message, inner) { }
    protected BookNotFindException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }
}
