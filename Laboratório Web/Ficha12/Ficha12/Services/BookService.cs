using Ficha12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ficha12.Services
{
    //Os serviços são sempre onde vão estar os CRUD
    public class BookService : IBookService
    {
        private readonly LibraryContext context;

        public BookService(LibraryContext context)
        {
            this.context = context;
        }

        public Book Create(Book newBook)
        {
            Publisher pub = context.Publishers.Find(newBook.Publisher.ID);

            if (pub is null)
            {
                throw new NullReferenceException("Publisher does not exist");
            }
            else
            {
                newBook.Publisher = pub;
                context.Books.Add(newBook);
                context.SaveChanges();
                return newBook;
            }
        }

        public void DeleteByISBN(string ISBN)
        {
            var book = context.Books.Find(ISBN);
            if (book is not null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }  
        }

        public IEnumerable<Book> GetAll()
        {
            var books = context.Books.Include(p => p.Publisher);
            return books;
        }

        public Book GetByISBN(string isbn)
        {
            var book = context.Books.Include(b=>b.Publisher).SingleOrDefault(b=>b.ISBN == isbn);
            return book;
        }

        public void Update(string isbn, Book Book)
        {
            var book = GetByISBN(isbn);
            if (book is null)
            {
                throw new NullReferenceException("Book does not exist");
            }
            else
            {
                book.Author = Book.Author;
                book.Publisher = Book.Publisher;
                book.Pages = Book.Pages;
                book.Language = Book.Language;
                book.Title = Book.Title;
                context.SaveChanges();
            }

        }

        public void UpdatePublisher(string isbn, int publisherId)
        {
            Book? book = context.Books.Find(isbn);
            Publisher? pub = context.Publishers.Find(publisherId);

            if(book is null || pub is null)
            {
                throw new NullReferenceException("Book does not exist");
            }

            book.Publisher = pub;
            context.SaveChanges();
        }

        public IEnumerable<Book> GetByAuthor(string author) //? - Pode ser nulo
        {

            var bookAuthor = context.Books.Include(p => p.Publisher).AsEnumerable().Where(p => p.Author == author);



            if (bookAuthor is null)
{
                throw new NullReferenceException("Books with this author does not exist");

            }



            else
            {

                return (IEnumerable<Book>)bookAuthor;

            }

        }
    }
}
