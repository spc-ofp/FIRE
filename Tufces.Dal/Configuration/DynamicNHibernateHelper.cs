using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUFMAN.DAL.Maps.Ves;

namespace Tufces.Dal.Configuration
{
    public class DynamicNHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            NHibernate.Cfg.Configuration config = Fluently.Configure().
                Database(MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(connectionString)).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<VesselsMap>()).
                CurrentSessionContext<ThreadStaticSessionContext>().
                BuildConfiguration();
            return config.BuildSessionFactory();
        }
    }
}