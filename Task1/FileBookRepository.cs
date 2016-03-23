
using System;
using System.Collections.Generic;
using System.IO;

namespace Task1{
   public class FileBookRepository: IBookRepository{
       private List<Book> books;
       private readonly FileInfo booksFile;
       private BinaryReader reader;
 
    public FileBookRepository(FileInfo booksFile){
        if (!booksFile.Exists)
            throw new FileNotFoundException("Could not find the books file to process.");

        this.booksFile = booksFile;
        Load();

    }
    public List<Book> GetBookList() {
        return books;
    }
    public Book GetBook(string name){
        Book findBook = books.Find(book => book.Name == name);
        if (findBook != null) return findBook;
        throw new BookNotFindException(String.Format("Book '{0}' doesn't find",name));
    }
    public void AddBook(Book book){
           Book sameBook = books.Find(b => b.Equals(book));
           if (sameBook == null) {
               books.Add(book);
           }
           else throw new BookExistException("This book already exist");
    }
 
    public void RemoveBook(string name) {
        Book deleteBook = books.Find(b => b.Name == name);
        if (deleteBook != null) {
            books.Remove(deleteBook);
            Save();
        }
        else throw new BookNotFindException(String.Format("Book '{0}' doesn't find",name));
    }
    public List<Book> FindAll(IEqualityComparer<Book> comparer){
           throw new NotImplementedException();
    }

    public List<Book> SortBooks(IComparer<Book> comparer){
           throw new NotImplementedException();
    }
   public void Save(){
        File.Delete(booksFile.FullName);
        using (var writer = new BinaryWriter(File.Open(booksFile.FullName, FileMode.OpenOrCreate))){
            foreach (Book b in books){
                writer.Write(b.Name);
                writer.Write(b.Author);
                writer.Write(b.Price);
            }
        }
    }
    public void Load() {
           books = new List<Book>();
           using (reader = new BinaryReader(File.Open(booksFile.FullName, FileMode.Open)))
           {
               while (reader.PeekChar() > -1){
                   string name = reader.ReadString();
                   string author = reader.ReadString();
                   int price = reader.ReadInt32();
                   books.Add(new Book(name, author, price));
               }
           }
       }
 
    private bool disposed = false;
 
    public virtual void Dispose(bool disposing){
        if(!disposed){
            if(disposing){
                books = null;

            }
        }
        disposed = true;
    }
 
    public void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    }
}
