using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApi.BussinessLayer;
using BookStoreApi.Model;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksBL booksBL = new BooksBL();
        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Books>> GetBooks()
        {
            var book = booksBL.GetBooks();
            return Ok(book);
        }

        // GET api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Books> GetBooks(int id)
        {
            var book = booksBL.GetBooks(id);
            if(book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }
            return Ok(book);
        }

        // GET api/Books/author
        [HttpGet("author/{author}")]
        public ActionResult<Books> GetBooks(string author)
        {
            var book = booksBL.GetBooks(author);
            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }
            return Ok(book);
        }

        // POST api/Books
        [HttpPost]
        public ActionResult<Books> PostBooks(Books book) 
        {
            booksBL.AddBooks(book);
            return Ok(book);
        }

        // PUT api/Books/5
        [HttpPut("{id}")]
        public ActionResult PutBooks(int id, Books book)
        {
            var ex = booksBL.GetBooks(id);
            if(ex == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            booksBL.UpdateBooks(id, book);
            return Ok(new { Message = "Product updated successfully" });

        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ex = booksBL.GetBooks(id);
            if (ex == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            booksBL.DeleteBook(id);
            return Ok(new { Message = "Book deleted successfully" });
        }
    }
}
