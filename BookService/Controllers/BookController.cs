using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookLibrary;

namespace BookService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>();

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        [HttpGet("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> GetOne(string isbn)
        {
            Book selectedBook = books.FirstOrDefault(e => e.Isbn13 == isbn);

            if (selectedBook != null)
            {
                return Ok(selectedBook);
            }
            
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Book> Create([FromBody] Book b)
        {
            books.Add(b);

            return Ok(b);
        }
        
        [HttpPut("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> Update(string isbn, [FromBody] Book b)
        {
            int index = books.FindIndex(e => e.Isbn13 == isbn);

            if (index >= 0)
            {
                books[index] = b;

                return Ok(b);
            }

            return NotFound();
        }
        
        [HttpDelete("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(string isbn)
        {
            books.RemoveAll(e => e.Isbn13 == isbn);

            return Ok();
        }
    }
}
