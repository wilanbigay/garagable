using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garagable.Service {

    public interface IEncryptor {
        string Encrypt(string inputText);
        string Decrypt(string cipherText);
    }

}
