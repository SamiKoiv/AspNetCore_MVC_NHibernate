using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NHibernateDataAccess.Repositories
{
    internal class NHibernateRepository
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        public NHibernateRepository()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=localhost;Initial Catalog=MyDB;Integrated Security=True").ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepository>())
                .BuildSessionFactory();
        }

        public List<T> Get<T>() where T : class
        {
            List<T> results;

            using (var session = _sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var criteria = session.CreateCriteria<T>();
                    var list = criteria.List<T>();
                    session.GetCurrentTransaction().Commit();

                    results = list.ToList();
                }
            }

            return results;
        }

        public void Save<T>(T obj)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Save(obj);
                    session.GetCurrentTransaction().Commit();
                }
            }
        }

        public void Delete<T>(Guid id) where T : class
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Delete("DELETE FROM Tasks WHERE Id = ?", id, new GuidType());
                    session.GetCurrentTransaction().Commit();
                }
            }
        }

    }
}
