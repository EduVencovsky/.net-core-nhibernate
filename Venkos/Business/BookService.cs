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
        protected IBookRepository BookRepository { get; set; }

        public BookService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks() => BookRepository.Queryable.ToList();

        public IEnumerable<Book> Get() => BookRepository.Find();
        
        public void AddBook(Book book) => BookRepository.Add(book);

        public void DeleteBook(Book book) => BookRepository.Delete(book);
    }
}
