using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Model;

namespace Garagable.Service.Contract {

    public interface IRoleSecurityService {
        IEnumerable<Role> GetRoles();
        Role GetRoleByName(string roleName);
        Role GetRoleById(int id);
        Role CreateRole(Role role);
        void DeleteRole(string roleName);
        void DeleteRole(int roleId);
        void UpdateRole(Role role);
    }

}
