using Entity.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace API.User.Util
{
    public class Authentication : GenericAuthenticationFilter
    {
        public Authentication()
        {

        }
        public Authentication(bool isActive)
            : base(isActive)
        {
        }
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUserService)) as IUserService;
            if (provider != null)
            {
                var userId = provider.Authenticate(username, password);
                if (userId > 0)
                {
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;

                    if (basicAuthenticationIdentity != null)
                    {
                        basicAuthenticationIdentity.UserId = userId;
                        return true;
                    }
                }
            }
            throw new Exception("Unauthorized");
        }
    }
}