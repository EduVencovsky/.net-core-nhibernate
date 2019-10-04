using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;

namespace Venkos.Domain.Business
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();

        void AddBook(Book book);

        IEnumerable<Book> Get();

        void DeleteBook(Book book);
    }
}
