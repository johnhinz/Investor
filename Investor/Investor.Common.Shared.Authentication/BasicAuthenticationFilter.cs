using Investor.Common.Shared.Interfaces;
//using Microsoft.Practices.Unity;
using System;
//using System.Collections.Generic;
using System.Configuration;
//using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
//using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace Investor.Common.Shared.Authentication
{
    /// <summary>
    /// Generic Basic Authentication filter that checks for basic authentication
    /// headers and challenges for authentication if no authentication is provided
    /// Sets the Thread Principle with a GenericAuthenticationPrincipal.
    /// 
    /// You can override the OnAuthorize method for custom auth logic that
    /// might be application specific.    
    /// </summary>
    /// <remarks>Always remember that Basic Authentication passes username and passwords
    /// from client to server in plain text, so make sure SSL is used with basic auth
    /// to encode the Authorization header on all requests (not just the login).
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthenticationFilter : AuthorizationFilterAttribute
    {
        private readonly bool _active = true;
        public BasicAuthenticationFilter()
        {
            bool.TryParse(ConfigurationManager.AppSettings["EnableAuthentication"], out _active);
        }
        public BasicAuthenticationFilter(bool active)
        {
            _active = active;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (_active)
            {
                var identity = ParseAuthorizationHeader(actionContext);
                if (identity == null)
                {
                    Challenge(actionContext);
                    return;
                }


                if (!OnAuthorizeUser(identity.Name, identity.Password, actionContext))
                {
                    Challenge(actionContext);
                    return;
                }

                var principal = new GenericPrincipal(identity, null);

                Thread.CurrentPrincipal = principal;

                // inside of ASP.NET this is required
                //if (HttpContext.Current != null)
                //    HttpContext.Current.User = principal;

                base.OnAuthorization(actionContext);
            }
        }
        protected virtual bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;
            var repo = actionContext.ControllerContext.
                Configuration.DependencyResolver.GetService(typeof(IAuthenticationRepository)) as IAuthenticationRepository;
            return repo.Verify(username, password);
        }

        protected virtual BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            if (auth?.Scheme == "Basic")
                authHeader = auth.Parameter;

            if (string.IsNullOrEmpty(authHeader))
                return null;
            try
            {
                authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));
            }
            catch
            {
                throw new Exception("Invalid Base-64 char array. (Authorization header)");
            }

            var tokens = authHeader.Split(':');
            if (tokens.Length < 2)
                return null;

            return new BasicAuthenticationIdentity(tokens[0], tokens[1]);
        }


        /// <summary>
        /// Send the Authentication Challenge request
        /// </summary>
        /// <param name="message"></param>
        /// <param name="actionContext"></param>
        void Challenge(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
        }

    }
}