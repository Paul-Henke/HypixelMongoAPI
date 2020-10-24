using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hypixel.BusinessLogic
{
    public class GetHTTPResponse
    {
        public Stream getResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.PreAuthenticate = true;
            var response = request.GetResponse() as HttpWebResponse;
            return response.GetResponseStream();
        }
    }
}
