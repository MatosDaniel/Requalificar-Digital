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
        public Book Post([FromBody] Book book)
        {
            return service.Create(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{ISBN}", Name="Update ")]
        public IActionResult Put(string ISBN, [FromBody] Book Book)
        {
            Book? book = service.Update(ISBN, book);

        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{ISBN}" , Name ="Delete")]
        public IActionResult Delete(string ISBN)
        {
            Book? book = service.DeleteByISBN(ISBN);
            if(book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok($"O livro com o ISBN {ISBN} foi eliminado");
            }

        }
    }
}
