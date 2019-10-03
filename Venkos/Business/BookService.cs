using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Business;
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
    }
}
