
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Translation.Service
{
    public class GoogleApi
    {
        public string Translation(string context)
        {
           string googleReulst= RequestApi(context);
           return googleReulst;
        }

        private string RequestApi(string context)
        {
            var str = System.Web.HttpUtility.UrlEncode(context);
            string url =
                string.Format(
                    "https://ajax.googleapis.com/ajax/services/language/translate?v=1.0&q={0}&langpair=zh|en", str);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (stream == null) return null;
            StreamReader streamReader=new StreamReader(stream);
            var result=streamReader.ReadToEnd();
            streamReader.Dispose();
            stream.Dispose();
            response.Close();
            return result;
        }
    }
}
