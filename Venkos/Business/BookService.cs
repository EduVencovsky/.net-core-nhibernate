using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Data.Repository;
using Venkos.Domain.Business;
using Venkos.Domain.Model;
using Venkos.Domain.Repository;

namespace Venkos.Business
{
    public class BookService : IBookService
    {
        protected IBookRepository _bookRepository { get; set; }

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks() => _bookRepository.Queryable.ToList();

        public void AddBook(Book book) => _bookRepository.Add(book);

        public IEnumerable<Book> Get() => _bookRepository.Find();
    }
}
