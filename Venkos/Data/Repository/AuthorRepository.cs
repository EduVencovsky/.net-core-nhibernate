using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;
using Venkos.Domain.Repository;

namespace Venkos.Data.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public Author GetByName(string name) => GetOne(author=> author.Name == name);

    }
}
