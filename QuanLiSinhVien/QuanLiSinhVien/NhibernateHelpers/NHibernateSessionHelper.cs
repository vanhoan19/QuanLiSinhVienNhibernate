using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace QuanLiSinhVien.NhibernateHelpers
{
    public static class NHibernateSessionHelper
    {
        public static ISessionFactory GetNHibernateFactory()
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(config => {

                config.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                config.Driver<NHibernate.Driver.SqlClientDriver>();
                config.ConnectionString = "Data Source=HOANBABE-CUTE19\\SQLEXPRESS;Initial Catalog=QuanLiSinhVien;Integrated Security=True";
                config.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
            });

            configuration.CurrentSessionContext<WebSessionContext>();

            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            return configuration.BuildSessionFactory();
        }
    }
}