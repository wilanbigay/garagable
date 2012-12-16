using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Garagable.Helpers;
using Garagable.Model;
using Garagable.Service;
using Garagable.Service.Contract;
using Garagable.Web.Properties;

namespace Garagable.Web.Infrastructure {

    public class TokenValidatorMessageHandler : DelegatingHandler {

        private const string TokenKey = "x-garagable-auth-token";

        private readonly ISecurityService _securityService;

        public TokenValidatorMessageHandler(ISecurityService securityService) {
            _securityService = securityService;
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) {


            if (request.Headers.Contains(TokenKey))  {
                string accessToken = request
                                        .Headers
                                        .First(h => TokenKey.Equals(h.Key))
                                        .Value
                                        .First()
                                        .DecodeFromBase64();

                IUserTokenValidator tokenValidator = new SimpleTokenValidator(_securityService, Settings.Default.TokenValidMinutes);
                if (!tokenValidator.Validate(accessToken))
                    return Task<HttpResponseMessage>.Factory.StartNew(
                                () => new HttpResponseMessage(HttpStatusCode.Unauthorized));

                User user = tokenValidator.GetValidUser();
                SetCurrentUserPrincipal(user);
            }
            
            return base.SendAsync(request, cancellationToken);

        }

        private void SetCurrentUserPrincipal(User user) {
            var principal = new GenericPrincipal(new GenericIdentity(user.UserName, "Basic"), 
                user.Roles.Select(r => r.RoleName).ToArray());
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
        }



    }

}