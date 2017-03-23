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
            _books.Add(new Book() { Id = 1, Name = "P=NP in .NET", Author = "Jon Skeet" });
            _books.Add(new Book() { Id = 2, Name = "Dank Memes", Author = "Dasith Wijes" });
            _books.Add(new Book() { Id = 3, Name = "50 'Shards' of Azure SQL", Author = "Actor Model" });
            _books.Add(new Book() { Id = 4, Name = "Jailbreaking iOS to Set a Default Web Browser", Author = "Cult Of Fandroid" });
            _books.Add(new Book() { Id = 5, Name = "OCD Olympics", Author = "Also Me" });
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.ToArray();
        }

        public void UpdateBook(Book b)
        {
            _books[_books.IndexOf(_books.Single(o => o.Id == b.Id))] = b;
        }

        public int AddBook(Book b)
        {
            b.Id = _books.Max(o=> o.Id) + 1;
            _books.Add(b);

            return b.Id;
        }

        public void DeleteBook(int id)
        {
            _books.Remove(_books.Single(o => o.Id == id));
        }
    }
}
