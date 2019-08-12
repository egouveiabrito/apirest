using API.User.Util;
using Entity.Interfaces.Services;
using Entity.Util;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Entities;
using System.Threading;

namespace API.User.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage ExceptionProcess(Exception ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            Response error = new Response();
            error.message = ex.Message;
            error.errorCode = 123;
            return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
        }

        [Route("Me")]
        [Authentication]
        [HttpGet]
        public HttpResponseMessage Me()
        {
            var response = new HttpResponseMessage();
            try
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity; // obter  id da autorização.
                Entity.Entities.User User = _userService.Me(basicAuthenticationIdentity.UserId);
                return Request.CreateResponse(HttpStatusCode.OK, User);
            }
            catch (Exception ex)
            {
                response = this.ExceptionProcess(ex);
            }
            return response;
        }

        [Route("Signup")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Signup([FromBody]Entity.Entities.User user)
        {
            var response = new HttpResponseMessage();
            try
            {
                user = _userService.Signup(user);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                response = this.ExceptionProcess(ex);
            }
            return response;
        }

        [Route("Signin")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Signin([FromBody]Login login)
        {
            var response = new HttpResponseMessage();

            try
            {
                var user = _userService.Signin(login);

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                response = this.ExceptionProcess(ex);
            }
            return response;
        }
    }
}
