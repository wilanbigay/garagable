using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Model;

namespace Garagable.Service.Contract {

    public interface ISecurityService : IUserSecurityService, IRoleSecurityService {

        void Save();

        void AssignUserToRole(string userName, IEnumerable<string> roleNames);
        bool IsUserInRole(string userName, IEnumerable<string> roleNames);
        string CreateLoginToken(User user);
    }

}
