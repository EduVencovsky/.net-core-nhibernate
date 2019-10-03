using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Venkos.Domain.Repository;

namespace Venkos.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public virtual IQueryable<T> Queryable => Session.Query<T>();

        protected ISessionFactory SessionFactory { get; }

        protected ISession Session => SessionFactory.GetCurrentSession();

        public BaseRepository(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        public void Add(T entity)
        {
            Session.Save(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Add(entity);
        }

        public bool Any() => Queryable.Any();

        public bool Any(Expression<Func<T, bool>> filter) => Queryable.Any(filter);

        public void Clear() => Session.Clear();

        public long Count(Expression<Func<T, bool>> filter) => Queryable.Where(filter).Count();

        public void Delete(T entity) => Session.Delete(entity);

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Delete(entity);
        }

        public void Delete(object id)
        {
            var entity = Load(id);
            Delete(entity);
        }

        public void Delete(IEnumerable<long> ids)
        {
            foreach (var id in ids)            
                Delete(id);
        }

        public IEnumerable<T> Find() => Queryable.ToList();

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter) => Queryable.Where(filter).ToList();

        public void Flush() => Session.Flush();

        public T Get(object id) => Session.Get<T>(id);

        public T GetOne(Expression<Func<T, bool>> filter) => Queryable.Where(filter).FirstOrDefault();

        public T Load(object id) => Session.Load<T>(id);

        public void Merge(T entity) => Session.Merge(entity);

        public void Merge(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Merge(entity);
        }

        public void Save(T entity) => Session.SaveOrUpdate(entity);

        public void Save(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Save(entity);
        }

        public void Update(T entity) => Session.Update(entity);

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }
    }
}
