using AutoMapper;
using Nicom.Timesheets.Data;
using Nicom.Timesheets.Entities;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nicom.Timesheets.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Project, ProjectModel>()
                    .ForMember(dest => dest.Client, opt => opt.Ignore())
                    .ForMember(dest => dest.ProjectUserRates, opt => opt.Ignore())
                    .ForMember(dest => dest.TimesheetEntries, opt => opt.Ignore())
                    .ForMember(dest => dest.UserTasks, opt => opt.Ignore());

                cfg.CreateMap<Timesheet, TimesheetModel>()
                    .ForMember(dest => dest.TimesheetEntries, opt => opt.Ignore())
                    .ForMember(dest => dest.User, opt => opt.Ignore());

                cfg.CreateMap<TimesheetEntry, TimesheetEntryModel>()
                    .ForMember(dest => dest.Timesheet, opt => opt.Ignore())
                    .ForMember(dest => dest.Project, opt => opt.Ignore());

                cfg.CreateMap<User, UserModel>()
                    .ForMember(dest => dest.ClientUserRates, opt => opt.Ignore())
                    .ForMember(dest => dest.ProjectUserRates, opt => opt.Ignore())
                    .ForMember(dest => dest.Timesheets, opt => opt.Ignore())
                    .ForMember(dest => dest.UserTasks, opt => opt.Ignore());
            });
        }
    }
}