using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SubindoNivel.Entity.Entities;
using System;

namespace SubindoNivel.Repository
{
    public abstract class InMemoryDatabase : IDisposable
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;

        protected ISession Session { get; set; }

        protected InMemoryDatabase()
        {
            _sessionFactory = Fluently.Configure()
                .Mappings(M => M.FluentMappings.AddFromAssemblyOf<Pessoa>())
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())                
                .ExposeConfiguration(Cfg => _configuration = Cfg)
                .BuildSessionFactory();
        }

        protected void CreateSchema()
        {
            Session = _sessionFactory.OpenSession();

            new SchemaExport(_configuration).Execute(true, true, false, Session.Connection, null);
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
