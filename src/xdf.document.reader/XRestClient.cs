/*
 * Author: Danny Xiang
 * Date: 2023/10/25
 * Description:
 * 
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace XDF.Tools.Common
{
    public static class XRestClient
    {
        static readonly string contentType = "application/json";
        static readonly Encoding encoding = Encoding.UTF8;

        private static string CreateUrlParameters(Dictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            if (parameters != null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    sb.Append($"{kvp.Key}={kvp.Value}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }

        public static ApiResult<string> Invoke(string url, Dictionary<string, string> query, object body, Dictionary<string, string> headers, string method, int timeout = 15000)
        {
            var qstring = CreateUrlParameters(query);
            try
            {
                url = string.IsNullOrEmpty(qstring) ? url : $"{url}?{qstring}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.ContentType = contentType;
                request.Timeout = timeout;
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in headers)
                    {
                        request.Headers.Add(kvp.Key, kvp.Value);
                    }
                }
                if (body != null && !string.Equals("GET", method, StringComparison.OrdinalIgnoreCase))
                {
                    using (var ins = request.GetRequestStream())
                    {
                        using (var insw = new StreamWriter(ins, encoding))
                        {
                            var inj = (body is string)? body as string: JsonConvert.SerializeObject(body);
                            insw.Write(inj);
                            insw.Flush();
                        }
                    }
                }
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return Read(response);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log("XRestClient.Invoke", $"WebApi调用发生异常,Url: {url}, Method: {method}", ex);
                return new ApiResult<string>()
                {
                    Code = -1,
                    Error = $"{ex.Message}, Url: {url}, Method: {method}"
                };
            }
        }

        public static ApiResult<string> Post(string url, Dictionary<string, string> qstring, object body, int timeout = 15000)
        {
            return Invoke(url, qstring, body, null, "POST", timeout);
        }

        public static ApiResult<string> Invoke(string url, object body, string method = "GET", int timeout = 15000)
        {
            return Invoke(url, null, body, null, method, timeout);
        }

        public static ApiResult<string> Get(string url, Dictionary<string, string> qstring)
        {
            return Invoke(url, qstring, null, null, "GET");
        }

        public static ApiResult<string> Get(string url, Dictionary<string, string> qstring, Dictionary<string, string> headers)
        {
            return Invoke(url, qstring, null, headers, "GET");
        }

        private static ApiResult<string> Read(HttpWebResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var headers = new Dictionary<string, string>();
                var keys = response.Headers.Keys;
                foreach(string k in keys)
                {
                    headers.Add(k, response.Headers[k]);
                }
                using (var stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        var data = sr.ReadToEnd();
                        return new ApiResult<string>(data)
                        {
                            Headers = headers,
                            Code = (int)HttpStatusCode.OK
                        };
                    }
                }
            }
            else
            {
                return new ApiResult<string>()
                {
                    Code = (int)response.StatusCode,
                    Error = response.StatusDescription
                };
            }
        }

        public static ApiResult<string> Post(string url, object body)
        {
            return Invoke(url, body, "POST");
        }
    }
}
