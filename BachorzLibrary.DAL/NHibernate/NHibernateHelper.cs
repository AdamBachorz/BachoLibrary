using BachorzLibrary.DAL;
using BachorzLibrary.DAL.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BachorzLibrary.DAL.NHibernate
{
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly FluentConfiguration _configuration;
        private readonly IFluentNHibernateCustomConfig _customConfig;

        public NHibernateHelper(IFluentNHibernateCustomConfig customConfig)
        {
            _customConfig = customConfig;
            _configuration = _customConfig.BuildNHibernateConfiguration();
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        public ISession OpenSession() => _sessionFactory.OpenSession();

        public IFluentNHibernateCustomConfig CustomConfig => _customConfig;
    }
}
