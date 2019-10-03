using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venkos.NHibernate
{
    public class NHibernateMapperSession<T> : IMapperSession<T>
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateMapperSession(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> Books => _session.Query<T>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(T entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(T entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
