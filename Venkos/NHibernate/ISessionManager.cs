using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venkos.NHibernate
{
    interface ISessionManager
    {
        void BeginTransaction();

        Task Commit();

        Task Rollback();

        void CloseTransaction();
    }
}
