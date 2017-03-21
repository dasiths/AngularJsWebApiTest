using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularWebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace AngularWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class BooksController : Controller
    {

        private List<Book> _books = new List<Book>();

        public BooksController()
        {
            _books.Add(new Book() { Name = "Book ABC", Author = "Author ABC" });
            _books.Add(new Book() { Name = "Book XYZ", Author = "Author XYZ" });
            _books.Add(new Book() { Name = "Book 123", Author = "Author 123" });
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_books);
        }

        // GET api/books/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(_books.Where(
                o => o.Name.IndexOf(name, 0, StringComparison.OrdinalIgnoreCase) > 0).ToList());
        }

    }
}
