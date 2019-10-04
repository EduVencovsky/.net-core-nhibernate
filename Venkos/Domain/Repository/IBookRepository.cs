using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;

namespace Venkos.Domain.Repository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Book GetByTitle(string title);
    }
}
