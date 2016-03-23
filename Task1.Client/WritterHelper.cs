using System;
using System.Collections.Generic;
using Task1.BookExceptions;

namespace Task1.Client{
    public static class WritterHelper{
        public static void WriteListCommands(){
            Console.WriteLine("Enter number:");
            Console.WriteLine("1) show whole collection");
            Console.WriteLine("2) add new book");
            Console.WriteLine("3) delete book");
            Console.WriteLine("4) save to file");
            Console.WriteLine("5) exit");
            Line();
        }
        public static void AddBook(BookRepository db){
            string name, author;
            int price;
            Console.WriteLine("Enter book's name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter book's author: ");
            author = Console.ReadLine();
            Console.WriteLine("Enter book's price: ");
            if (!int.TryParse(Console.ReadLine(), out price)){
                Console.WriteLine("Incorrect value of price: ");
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
            Console.WriteLine("Enter book's name: ");
            string name = Console.ReadLine();
            try{
                db.Remove(name);
                Console.WriteLine("Book '{0}' delete", name);
            }
            catch (BookNotFondException ex){
                Console.WriteLine(ex.Message);
            }
            Line();
        }
        public static void GetAllBooks(BookRepository db){
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

        public static void SaveToFile(BookRepository db) {
            db.Save();
            Console.WriteLine("Done.");
        }

        public static void IncorrectComand(){
            Console.WriteLine("You write incorrect command. Try again.");
        }
        public static void Line(){
            Console.WriteLine("=======================================================");
        }



    }
}
