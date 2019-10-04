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
    public class AuthorService : IAuthorService
    {
        protected IAuthorRepository AuthorRepository { get; set; }

        public AuthorService(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAuthors() => AuthorRepository.Queryable.ToList();

        public IEnumerable<Author> Get() => AuthorRepository.Find();
        
        public void AddAuthor(Author author) => AuthorRepository.Add(author);

        public void DeleteAuthor(Author author) => AuthorRepository.Delete(author);
    }
}
