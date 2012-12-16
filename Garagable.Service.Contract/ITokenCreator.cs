using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garagable.Service.Contract {
    public interface ITokenCreator {
        string CreateToken();
    }
}
