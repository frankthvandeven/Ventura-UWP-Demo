using System.Collections.Generic;

namespace Ventura.Controls
{
    public static class Books
    {
        public static List<Book> GetList()
        {
            // 42 iterations is about 500 rows


            List<Book> books = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                books.Add(new Book() { Author = "Allen", Price = 29.99M, Name = "War" });
                books.Add(new Book() { Author = "Carter", Price = 35.00M, Name = "Fighting Like A Man" });
                books.Add(new Book() { Author = "Rose", Price = 39.99M, Name = "Tomorrow" });
                books.Add(new Book() { Author = "Daisy", Price = 99.00M, Name = "Last Three Days" });
                books.Add(new Book() { Author = "Mary", Price = 10.00M, Name = "Fire Wall" });
                books.Add(new Book() { Author = "Ray", Price = 19.99M, Name = "Lie" });
                books.Add(new Book() { Author = "Sherry", Price = 45.50M, Name = "Three Wolves" });
                books.Add(new Book() { Author = "Lisa", Price = 36.99M, Name = "Beauty" });
                books.Add(new Book() { Author = "Judy", Price = 12.00M, Name = "The One" });
                books.Add(new Book() { Author = "Jack", Price = 88.99M, Name = "Chosen by God" });
                books.Add(new Book() { Author = "May", Price = 130.00M, Name = "The Magic" });
                books.Add(new Book() { Author = "Vivian", Price = 299.99M, Name = "Who is the Murder" });
            }

            return books;
        }
    }

    public class Book
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
    }
    
}
