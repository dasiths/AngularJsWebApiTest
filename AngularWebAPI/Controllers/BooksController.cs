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
            var result = _repo.GetAllBooks();

            if (result.Count() > 0)
                return Ok(result);
            else
                return NoContent();
        }

        // GET api/books/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repo.GetAllBooks().SingleOrDefault(o => o.Id == id);

            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        // GET api/books/q=query
        [HttpGet("q={name}")]
        public IActionResult Get(string name)
        {
            var results = _repo.GetAllBooks().Where(
                o => o.Name.IndexOf(name, 0, StringComparison.OrdinalIgnoreCase) >= 0);

            if (results.Count() > 0)
            {
                return Ok(results);
            }
            else
            {
                return NoContent();
            }

        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book b)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            return Ok(_repo.AddBook(b));
        }

        // PUT api/books/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book b)
        {

            if (ModelState.IsValid == false || id != b.Id)
                return BadRequest();

            var result = _repo.GetAllBooks().SingleOrDefault(o => o.Id == id);
            if (result == null)
                return NotFound();

            _repo.UpdateBook(b);

            return Ok(id);
        }

        // DELETE api/books/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteBook(id);
            return Ok(id);
        }

    }
}
