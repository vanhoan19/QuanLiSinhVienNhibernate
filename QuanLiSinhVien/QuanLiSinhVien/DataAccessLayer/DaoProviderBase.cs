using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.DataAccessLayer
{
    public abstract class DaoProviderBase<T, V> : IDaoProvider<T, V> where T : new()
        where V : class
    {   
        protected readonly ISession _currentNHibernateSession;
        protected DaoProviderBase()
        {
            _currentNHibernateSession = MvcApplication.NHibernateFactory.GetCurrentSession();
        }
        public T Create(T t)
        {
            using(ITransaction transaction = _currentNHibernateSession.BeginTransaction())
            {
                _currentNHibernateSession.Save(t);
                transaction.Commit();
            }
            return t;
        }

        public List<T> GetAll()
        {
            var icriteria = _currentNHibernateSession.CreateCriteria(typeof(T));
            return icriteria.List<T>().ToList();
        }

        public T GetObjectByID(V v)
        {
            return (T) _currentNHibernateSession.Load(typeof(T), v);
        }

        public void Update(T t)
        {
            using (ITransaction transaction = _currentNHibernateSession.BeginTransaction())
            {
                _currentNHibernateSession.Update(t);
                transaction.Commit();
            }
        }
    }
}