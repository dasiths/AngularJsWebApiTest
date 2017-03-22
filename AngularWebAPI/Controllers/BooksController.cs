using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularWebAPI.Models;
using Microsoft.AspNetCore.Cors;
using AngularWebAPI.Repository;

namespace AngularWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class BooksController : Controller
    {

        BookRepository _repo;

        public BooksController(BookRepository repo)
        {
            _repo = repo;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllBooks());
        }

        // GET api/books/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(_repo.GetAllBooks().Where(
                o => o.Name.IndexOf(name, 0, StringComparison.OrdinalIgnoreCase) > 0).ToList());
        }

    }
}
