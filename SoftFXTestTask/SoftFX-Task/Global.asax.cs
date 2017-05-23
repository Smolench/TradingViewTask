using AutoMapper;
using SoftFXTestTask.App_Start;
using SoftFXTestTask.AutoMapper;
using SoftFXTestTask.EntityFramework;
using System.Timers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SoftFXTestTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var timer = new Timer {Interval = 5000};
            timer.Elapsed += AddData;
            Mapper.Initialize(cfg => cfg.AddProfile<MapperProfile>());
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddData(object sender, System.Timers.ElapsedEventArgs e)
        {
            var db = new DataBaseContext();
            CustomDatas.AddQuotesData(db);
            db.SaveChanges();
        }
    }
}
