using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Helpers;

namespace Garagable.Service {

    public class RijndaelEncryptor : IEncryptor {

        private readonly string _salt;

        public RijndaelEncryptor(string salt) {
            _salt = salt;
        }

        public string Encrypt(string inputText) {
            return inputText.Encrypt(_salt);
        }

        public string Decrypt(string cipherText) {
            return cipherText.Decrypt(_salt);
        }
    }

}
