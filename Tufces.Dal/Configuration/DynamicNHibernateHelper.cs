using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tufces.Dal.Maps;
using Tufces.Dal.Maps.Tufman.Ves;

namespace Tufces.Dal.Configuration
{
    public class DynamicNHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            NHibernate.Cfg.Configuration config = Fluently.Configure().
                Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString)).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<VesselMap>()).
                CurrentSessionContext<ThreadStaticSessionContext>().
                BuildConfiguration();
            return config.BuildSessionFactory();
        }
    }
}