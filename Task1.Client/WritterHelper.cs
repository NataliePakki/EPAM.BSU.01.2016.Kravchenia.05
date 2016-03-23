using System;
using System.Collections.Generic;
using Task1.BookExceptions;
using Task1.Find;
using Task1.Sort;

namespace Task1.Client{
    public static class WritterHelper{
        public static void WriteListCommands(){
            Console.WriteLine("Enter number:");
            Console.WriteLine("1) show whole collection");
            Console.WriteLine("2) add new book");
            Console.WriteLine("3) delete book");
            Console.WriteLine("4) sort books by name");
            Console.WriteLine("5) sort books by author");
            Console.WriteLine("6) sort books by price");
            Console.WriteLine("7) find books by name");
            Console.WriteLine("8) find books by author");
            Console.WriteLine("9) find books by price");
            Console.WriteLine("0) save to file");
            Console.WriteLine("8) exit");
            Line();
        }
        public static void AddBook(BookRepository db){
            string name, author;
            int price;
            Clear();
            Console.WriteLine("ADD BOOK:");
            Line();
            Console.WriteLine("Enter book's name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter book's author: ");
            author = Console.ReadLine();
            Console.WriteLine("Enter book's price: ");
            if (!int.TryParse(Console.ReadLine(), out price)) {
                Clear();
                Console.WriteLine("Incorrect value of price: ");
                Line();
                return;
            }
            try{
                db.Add(new Book(name, author, price));
            }
            catch (BookExistException ex){
                Console.WriteLine(ex.Message);
            }
            Line();
        }

        public static void DeleteBook(BookRepository db){
            Clear();
            Console.WriteLine("DELETE BOOK: ");
            Line();
            Console.WriteLine("Enter book's name: ");
            string name = Console.ReadLine();
            try {
                Book book = db.GetBook(name);
                db.Remove(book);
                Console.WriteLine("Book '{0}' delete", name);
            }
            catch (BookNotFondException ex){
                Console.WriteLine(ex.Message);
            }
            Line();
        }
        public static void GetAllBooks(BookRepository db){
            Clear();
            Console.WriteLine("List of all books:");
            List<Book> books = db.GetList();
            if (books.Count == 0){
                Console.WriteLine("Catalog is empty.");
                return;
            }
            foreach (Book b in db.GetList()){
                Console.WriteLine(b.ToString());
            }
            Line();
        }

        public static void SortedByTag(BookRepository repository, string tag) {
            switch (tag) {
                case "name":
                    repository.Sort(new SortedByName());
                    break;
                case "author":
                    repository.Sort(new SortedByAuthor());
                    break;
                case "price":
                    repository.Sort(new SortedByPrice());
                    break;
            }
            Clear();
            Console.WriteLine("Book sorted by {0}",tag);
            Line();
        }
        public static void FindAllByTag(BookRepository repository, string tag){
            Clear();
            Console.WriteLine("FIND BY {0}: ", tag.ToUpper());
            Line();
            Console.WriteLine("Enter {0}: ", tag);
            string name = Console.ReadLine();
            var result = new List<Book>();
            switch (tag){
                case "name":
                    result = repository.FindAll(new EqualByName(),name);
                    break;
                case "author":
                    result = repository.FindAll(new EqualByAuthor(),name);
                    break;
                case "price":
                    result = repository.FindAll(new EqualByPrice(),name);
                    break;
            }
            Line();
            if (result.Count == 0) {
                Console.WriteLine("Don't find any books: ");
            } else {
                Console.WriteLine("Finded books: ");
                foreach (Book b in result) {
                    Console.WriteLine(b.ToString());
                }
            }
            Line();
        }


        public static void SaveToFile(BookRepository db) {
            Clear();
            db.Save();
            Console.WriteLine("Done.");
        }

        public static void IncorrectComand(){
            Clear();
            Console.WriteLine("You write incorrect command. Try again.");
        }

        public static void Clear() {
            Console.Clear();
        }
        public static void Line(){
            Console.WriteLine("=======================================================");
        }
    }
}
