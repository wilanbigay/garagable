using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garagable.Helpers {

    public static class Base64Helpers {

        public static string DecodeFromBase64(this string sInput) {
            return Encoding.UTF8.GetString(Convert.FromBase64String(sInput));
        }

        public static string EncodeToBase64(this string sInput) {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(sInput));
        }
    }

}
