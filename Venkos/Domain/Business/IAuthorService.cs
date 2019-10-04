using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;

namespace Venkos.Domain.Business
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAuthors();

        void AddAuthor(Author book);

        IEnumerable<Author> Get();

        void DeleteAuthor(Author book);
    }
}
