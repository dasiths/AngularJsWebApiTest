using AngularWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebAPI.Repository
{
    public class BookRepository
    {
        private List<Book> _books = new List<Book>();
        public BookRepository()
        {
            _books.Add(new Book() { Name = "P=NP in .NET", Author = "Jon Skeet" });
            _books.Add(new Book() { Name = "Dank Memes", Author = "Dasith Wijes" });
            _books.Add(new Book() { Name = "50 'Shards' of Azure SQL", Author = "Actor Model" });
            _books.Add(new Book() { Name = "Do you even", Author = "Lift" });
            _books.Add(new Book() { Name = "OCD Olympics", Author = "Also Me" });
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.ToArray();
        }
    }
}
