using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;
using Venkos.Domain.Repository;

namespace Venkos.Data.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public Book GetByTitle(string title) => GetOne(book => book.Title == title);

    }
}
