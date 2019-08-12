using Entity.Interfaces.Repositories;
using Entity.Interfaces.Services;
using Entity.Services;
using Infrastructure.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.User.Util
{
    public static class IOC
    {
        public static void RegisterIOC()
        {
            var container = new Container();

            #region Service
            container.Register<IUserService, UserService>(Lifestyle.Singleton);
            #endregion

            #region Repository
            container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);
            #endregion

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container); //web api
        }
    }
}