using System;
using System.Configuration;
using System.IO;

namespace Task1.Client{
    public class Program {
        private static void Main(string[] args) {
            string path = ConfigurationManager.AppSettings["pathFileBooks"];
            BookService repository = new BookService(new BookFileProvider(new FileInfo(path)));
            WritterHelper.WriteListRepositories();
            string command = Console.ReadLine();
            switch (command) {
                case "1":
                    path = ConfigurationManager.AppSettings["pathFileBooks"];
                    repository = new BookService(new BookFileProvider(new FileInfo(path)));
                    break;
                case "2":
                    path = ConfigurationManager.AppSettings["pathSerializeFileBooks"];
                    repository = new BookService(new BookSerializeFileProvider(new FileInfo(path)));
                    break;
                case "3":
                    path = ConfigurationManager.AppSettings["pathXmlBooks"];
                    repository = new BookService(new BookXmlProvider(new FileInfo(path)));
                    break;
                default:
                    WritterHelper.IncorrectComand();
                    break;
            }
             
            bool working = true;
            while (working) { 
            WritterHelper.WriteListCommands();
            command = Console.ReadLine();
                switch (command) {
                    case "1":
                        WritterHelper.GetAllBooks(repository);
                        break;
                    case "2":
                        WritterHelper.AddBook(repository);
                        break;
                    case "3":
                        WritterHelper.DeleteBook(repository);
                        break;
                    case "4":
                        WritterHelper.SortedByTag(repository,"name");
                        break;
                    case "5":
                        WritterHelper.SortedByTag(repository,"author");
                        break;
                    case "6":
                        WritterHelper.SortedByTag(repository,"price");
                        break;
                    case "7":
                        WritterHelper.FindAllByTag(repository, "name");
                        break;
                    case "8":
                        WritterHelper.FindAllByTag(repository, "author");
                        break;
                    case "9":
                        WritterHelper.FindAllByTag(repository, "price");
                        break;
                    case "0":
                        WritterHelper.SaveToFile(repository);
                        break;
                    case "l":
                        WritterHelper.Load(repository);
                        break;
                    case "q":
                        working = false;
                        break;
                    default:
                        WritterHelper.IncorrectComand();
                        break;
                        
                }

            }

        }
        
    }
}
