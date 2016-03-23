﻿using System;
using System.Collections.Generic;
using System.IO;
using Task1.BookExceptions;
using Task1.Interfaces;

namespace Task1 {
   public class BookRepository: IRepository<Book>{
       private List<Book> books;
       private readonly IBookProvider provider;
       
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
        Book findBook = books.Find(book => book.Name == name);
        if (findBook != null) return findBook;
        throw new BookNotFondException(String.Format("Book '{0}' wasn't found",name));
    }
    public void Add(Book book){
        if(book == null)
            throw new ArgumentNullException("Book is null");
        Book sameBook = books.Find(b => b.Equals(book));
        if (sameBook == null) {
               books.Add(book);
        }
           else throw new BookExistException("This book already exist");
    }
 
    public void Remove(Book book) {
        if (book == null)
            throw new ArgumentNullException("Book is null");
        Book deleteBook = books.Find(book.Equals);
        if (deleteBook != null) {
            books.Remove(deleteBook);
        }
        else throw new BookNotFondException(String.Format("Book '{0}' wasn't find", book.Name));
    }
    public List<Book> FindAll(IEqualityComparer<Book> comparer){
           throw new NotImplementedException();
    }

    public void Sort(IComparer<Book> comparer){
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
