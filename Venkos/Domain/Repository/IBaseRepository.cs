using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Venkos.Domain.Repository
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Queryable { get; }

        T Load(object id);

        T Get(object id);

        IEnumerable<T> Find();

        IEnumerable<T> Find(Expression<Func<T, bool>> filter);

        long Count(Expression<Func<T, bool>> filter);

        bool Any();

        bool Any(Expression<Func<T, bool>> filter);

        void Save(T entity);

        void Save(IEnumerable<T> entities);

        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        void Delete(object id);

        void Delete(IEnumerable<long> ids);

        void Merge(T entity);

        void Merge(IEnumerable<T> entities);

        /// <summary>
        /// Clear the context of the persistence.
        /// </summary>
        void Clear();

        /// <summary>
        /// Flush the context of the persistence.
        /// </summary>
        void Flush();

    }
}
