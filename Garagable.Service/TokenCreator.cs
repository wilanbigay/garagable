using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Service.Contract;

namespace Garagable.Service {
    public class TokenCreator : ITokenCreator {

        public string CreateToken() {
            return Guid.NewGuid().ToString();
        }
    }
}
