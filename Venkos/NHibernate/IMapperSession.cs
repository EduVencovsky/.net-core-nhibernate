using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venkos.NHibernate
{
    interface IMapperSession<T>
    {
        void BeginTransaction();

        Task Commit();

        Task Rollback();

        void CloseTransaction();

        Task Save(T entity);

        Task Delete(T entity);

        IQueryable<T> Books { get; }
    }
}
