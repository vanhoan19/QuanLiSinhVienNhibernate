using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Context;
using QuanLiSinhVien.Controllers;
using QuanLiSinhVien.DataAccessLayer;
using QuanLiSinhVien.NhibernateHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QuanLiSinhVien
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory NHibernateFactory;
        public override void Init()
        {
            this.BeginRequest += (sender, e) => {
                var session = NHibernateFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            };
            this.EndRequest += (sender, e) => {
                var session = CurrentSessionContext.Unbind(NHibernateFactory);
                session.Dispose();
            };
            base.Init();
        }
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NHibernateFactory = NHibernateSessionHelper.GetNHibernateFactory();
        }
    }
}
