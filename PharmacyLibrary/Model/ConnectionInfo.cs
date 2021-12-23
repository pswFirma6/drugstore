using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class ConnectionInfo
    {
        public string Url { get; set; }

        public string ApiKey { get; set; }

        public ConnectionInfo(string url, string apiKey)
        {
            Url = url;
            ApiKey = apiKey;
        }
    }
}
