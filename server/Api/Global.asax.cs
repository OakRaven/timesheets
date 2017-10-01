using AutoMapper;
using Nicom.Timesheets.Data;
using Nicom.Timesheets.Entities;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            ConfigureAutoMapper();
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>()
                    .ForMember(opt => opt.Timesheets, dest => dest.Ignore())
                    .ForMember(opt => opt.ClientUserRates, dest => dest.Ignore())
                    .ForMember(opt => opt.ProjectUserRates, dest => dest.Ignore());

                cfg.CreateMap<ClientUserRate, ClientUserRateModel>()
                    .ForMember(dest => dest.Client, opt => opt.Ignore())
                    .ForMember(dest => dest.User, opt => opt.Ignore());

                cfg.CreateMap<ProjectUserRate, ProjectUserRateModel>()
                    .ForMember(dest => dest.Project, opt => opt.Ignore())
                    .ForMember(dest => dest.User, opt => opt.Ignore());
            });
        }
    }
}