using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garagable.Model
{
    public class Smugmug
    {
        public string OauthConsumerKey { get; set; }
        public string OauthNonce { get; set; }
        public string OauthSignature { get; set; }
        public string OauthSignatureMethod { get; set; }
        public string OauthTimestamp { get; set; }
        public string OauthToken { get; set; }
        public string AlbumId { get; set; }
        public string Url { get; set; }

        public string SessionId { get; set; }
    }
}
