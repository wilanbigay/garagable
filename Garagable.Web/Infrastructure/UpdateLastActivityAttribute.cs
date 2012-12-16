using System.Web;
using Garagable.Service.Contract;

namespace Garagable.Web.Infrastructure {

    /// <summary>
    /// Logs the last activity of the user accessing thru WebAPI
    /// </summary>
    public class UpdateLastApiActivityAttribute : System.Web.Http.Filters.ActionFilterAttribute {

        private readonly ISecurityService _securityService;

        public UpdateLastApiActivityAttribute(ISecurityService securityService) {
            _securityService = securityService;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext) {
            var principal = HttpContext.Current.User;
            if (principal.Identity.IsAuthenticated) {
                var username = principal.Identity.Name;
                _securityService.UpdateLastActivity(username);
            }

            base.OnActionExecuting(actionContext);

        }

        /// <summary>
        /// Logs the last activity of the user accessing thru MVC
        /// </summary>
        public class UpdateLastWebActivityAttribute : System.Web.Mvc.ActionFilterAttribute {

            private readonly ISecurityService _securityService;

            public UpdateLastWebActivityAttribute(ISecurityService securityService) {
                _securityService = securityService;
            }

            public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext) {
                var httpContext = filterContext.HttpContext;
                if (httpContext.Request.IsAuthenticated)
                    _securityService.UpdateLastActivity(httpContext.User.Identity.Name);

                base.OnActionExecuting(filterContext);
            }


        }

    }

}