using Ficha12.Models;

namespace Ficha12.Services
{
    public interface IBookService
    {
        public abstract IEnumerable<Book> GetAll();
        public abstract Book GetByISBN(string isbn);
        public abstract Book Create(Book newBook);
        public abstract void DeleteByISBN(string ISBN);
        public abstract void Update(string isbn, Book Book);
        public abstract void UpdatePublisher(string isbn, int publisherId);
    }
}
