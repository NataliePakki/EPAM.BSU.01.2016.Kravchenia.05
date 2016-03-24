using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using Task1.BookExceptions;
using Task1.Interfaces;

namespace Task1 {
   public class BookRepository: IRepository<Book>{
       private List<Book> books;
       private readonly IBookProvider provider;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public BookRepository(FileInfo booksFile){
        provider = new BookFileProvider(booksFile);
        Load();
        }
    public BookRepository(IBookProvider provider) {
        this.provider = provider;
        Load();
    }
    public List<Book> GetList() {
        return books;
    }
    public Book GetBook(string name){
        logger.Info($"Get book '{name}': ");
        Book findBook = books.Find(book => book.Name == name);
        if (findBook != null) {
                logger.Info($"Book '{name}' was found.");
                return findBook;
        }
            logger.Warn($"GetBook({name}): Book '{name}' wasn't found.");
            throw new BookNotFondException($"Book '{name}' wasn't found.");
        }
    public void Add(Book book){
            logger.Info("Add book:");
            if (book == null) {
                logger.Error("Book is null");
                throw new ArgumentNullException("Book is null.");
        }
            logger.Info($"book: {book}:");
            Book sameBook = books.Find(b => b.Equals(book));
        if (sameBook == null) {
                logger.Info($"Book {book.Name} added.");
                books.Add(book);
        } else {
            logger.Error("This book already exist.");
            throw new BookAlreadyExistException("This book already exist.");
        }
    }
 
    public void Remove(Book book) {
            logger.Info($"Remove book:");
            if (book == null) {
                logger.Error("Book is null.");
                throw new ArgumentNullException($"Book is null");
        }
        Book deleteBook = books.Find(book.Equals);
        if (deleteBook != null) {
                logger.Info($"Book '{book.Name}' remove.");
                books.Remove(deleteBook);
        } else {
                logger.Error($"Book '{book.Name}' wasn't find");
                throw new BookNotFondException($"Book '{book.Name}' wasn't find");
        }
    }
    public List<Book> FindAll(IEqualityComparer<Book> comparer, string item) {
            logger.Info("FindAll:");
            int price;
        if (int.TryParse(item, out price)) {
            return books.FindAll(book => comparer.Equals(book, new Book(item, item, price)));
        }
        List<Book> result = books.FindAll(book => comparer.Equals(book, new Book(item, item, 0)));
            foreach(Book b in result)
            logger.Info("Finded book:" + b);
        return result;

    }

    public void Sort(IComparer<Book> comparer){
            logger.Info("Book sorted");
            books.Sort(comparer);
    }
   public void Save(){
       provider.Save(books);
    }
    public void Load() {
           provider.Load(out books);
    }
    private bool disposed = false;
 
    public virtual void Dispose(bool disposing){
        if(!disposed){
            if(disposing) {
                books = null;
            }
        }
        disposed = true;
    }
 
    public void Dispose(){
        Dispose(true);
    }
    }
}
