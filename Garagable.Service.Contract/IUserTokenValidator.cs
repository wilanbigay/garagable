using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Model;

namespace Garagable.Service.Contract {

    public interface IUserTokenValidator {
        bool Validate(string token);
        User GetValidUser();
    }

}
