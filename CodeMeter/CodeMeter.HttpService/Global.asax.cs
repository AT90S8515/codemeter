using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeMeter.HttpService.Models;
using CodeMeter.HttpService.Quartz;
using Quartz;
using Quartz.Impl;

namespace CodeMeter.HttpService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var c = new DataContext())
            {
                var cfg = c.Configurations.Single();
                var scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();
                var job = JobBuilder.Create<CheckJob>().WithIdentity("Check").Build();
                var trigger =
                    TriggerBuilder.Create()
                                  .WithIdentity("trigger")
                                  .WithSimpleSchedule(s => s.WithIntervalInMinutes(cfg.CheckInterval).RepeatForever())
                                  .StartAt(DateTime.Now.AddMinutes(cfg.CheckInterval))
                                  .Build();
                scheduler.ScheduleJob(job, trigger);
            }
            
        }
    }
}