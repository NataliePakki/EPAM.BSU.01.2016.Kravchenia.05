using System;
using System.Configuration;
using System.IO;

namespace Task1.Client{
    public class Program {

        private static void Main(string[] args) {
            string path = ConfigurationManager.AppSettings["pathFileBooks"];
            var repository = new FileBookRepository(new FileInfo(path));
            bool working = true;
            while (working) { 
            WritterHelper.WriteListCommands();
            string command = Console.ReadLine();
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
                        WritterHelper.SaveToFile(repository);
                        break;
                    case "5":
                        working = false;
                        break;
                }

            }

        }


        

    }
}
