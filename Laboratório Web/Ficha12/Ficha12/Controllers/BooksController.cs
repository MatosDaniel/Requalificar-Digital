using Ficha12.Models;
using Ficha12.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;
        private Book newBook;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return service.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{isbn}", Name = "GetByISBN")]
        public IActionResult Get(string isbn)
        {
            Book? book = service.GetByISBN(isbn);
            if(book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
       
        }

        // POST api/<BooksController>
        [HttpPost("/books")]
        public IActionResult Post([FromBody] Book book)
        {
            if(book != null)
            {
                Book newBook = service.Create(book);
                return CreatedAtRoute("GetByISBN", new { isbn = newBook.ISBN}, newBook);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{ISBN}", Name="Update ")]
        public IActionResult Put(string ISBN, [FromBody] Book Book)
        {
            var bookToUpdade = service.GetByISBN(ISBN);
            if (bookToUpdade is not null && Book is not null)
            {
                service.Update(ISBN, Book);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{ISBN}" , Name ="Delete")]
        public IActionResult Delete(string ISBN)
        {
            var book = service.GetByISBN(ISBN);
            
            if (book is not null)
            {
                service.DeleteByISBN(ISBN);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{isbn}/publisherId")]
        public IActionResult Patch(string isbn, int publisherId)
        {
            var bookToUpdate = service.GetByISBN(isbn);
            if(bookToUpdate is not null)
            {
                service.UpdatePublisher(isbn, publisherId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
