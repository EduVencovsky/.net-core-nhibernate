using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;

namespace Venkos.Domain.Repository
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Author GetByName(string title);
    }
}
