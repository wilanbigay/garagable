using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Model;
using Garagable.Service.Contract;

namespace Garagable.Service {

    /// <summary>
    /// This is a simple TokenValidator that will just look at the date of the token
    /// </summary>
    public class SimpleTokenValidator : IUserTokenValidator {

        private readonly ISecurityService _securityService;
        private readonly int _tokenExpiryInMinutes;
        private User _user;

        public SimpleTokenValidator(ISecurityService securityService, int tokenExpiryInMinutes) {
            _securityService = securityService;
            _tokenExpiryInMinutes = tokenExpiryInMinutes;
        }

        public bool Validate(string token) {
            _user = _securityService.GetUserByAccessToken(token);
            if (_user == null)
                return false;
            return !IsTokenExpired(_user);
        }

        private bool IsTokenExpired(User user) {
            if (!user.LastActivity.HasValue) {
                _user = user;
                return true;
            }

            TimeSpan inactivity = user.LastActivity.Value.Subtract(DateTime.Now);
            return inactivity.Minutes >= _tokenExpiryInMinutes;
        }

        public User GetValidUser() {
            return _user;
        }
    }

}
