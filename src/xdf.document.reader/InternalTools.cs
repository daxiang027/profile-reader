using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace xdf.document.reader
{
    internal static class InternalTools
    {
        internal static readonly string prompt_extract = @"学习标签内的公文/通告/通知/演讲稿文本,提取信息, 要求如下:
1. 输出格式为json.
2. 保留原文,如果原文未提及留空.
3. 日期字段可以是年月日也可以是年月或者年.
4. 发文日期一般都在发文单位的后面或者文本的末尾.
5. 要提取的信息包括: 公文标题, 发文单位, 发文日期, 文件号.
6. 其他内容不要返回.
```$txt```
";
        internal static readonly string prompt_summarize = @"学习标签内的公文/通告/通知/演讲稿文本, 输出内容摘要, 总的字数不要超过$count个字.
```$txt```
";

        internal static string model_name = "qwen2.5:7b";
        internal static string aiUrl = "http://127.0.0.1:11434/api/generate";

        internal static string PrettyJson(string json)
        {
            var obj = JObject.Parse(json);
            var result = obj.ToString();
            return result;
        }

        internal static async Task<string> Generate(string aiUrl, string bodyJson)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, aiUrl);

                // Create the content and set the content headers
                var content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                // Assign the content to the request
                request.Content = content;
                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                var respObj = JObject.Parse(resp);
                var respText = respObj["response"].ToString();
                return respText;
                //respText = respText.Substring(8).Replace("```", "");
                //return respText;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("application", $"xdf.document.reader : {ex}",EventLogEntryType.Error);
                return string.Empty;
            }
        }

        internal static async Task<string> Extract(string extractTxt)
        {
            var prompt = prompt_extract.Replace("$txt", extractTxt);
            var comObj = new
            {
                model = model_name,
                stream = false,
                prompt = prompt,
                options = new
                {
                    temperature = 0.2,
                    num_ctx = 16000
                }
            };
            var json = JsonConvert.SerializeObject(comObj);
            var respText = await Generate(aiUrl, json);
            respText = respText.Substring(8).Replace("```", "");
            return PrettyJson(respText);
        }

        internal static async Task<string> Summarize(string fullDocument,int maxWords=100)
        {
            var prompt = prompt_summarize.Replace("$txt", fullDocument).Replace("$count",maxWords.ToString());
            var comObj = new
            {
                model = model_name,
                stream = false,
                prompt = prompt,
                options = new
                {
                    temperature = 0.2,
                    num_ctx = 16000
                }
            };
            var json = JsonConvert.SerializeObject(comObj);
            return await Generate(aiUrl, json);
        }
        //internal static string Summarize(string extractTxt, string fullContent ,int summaryLength)
        //{
        //    var prompt = prompt_extract.Replace("$txt", extractTxt);
        //    var comObj = new {
        //        model = model_name,
        //        stream = false,
        //        prompt = prompt,
        //        options = new
        //        {
        //            temperature = 0.2,
        //            num_ctx = 16000
        //        }
        //    };
        //    var json = JsonConvert.SerializeObject(comObj);
        //    var data = Encoding.UTF8.GetBytes(json);
        //    try
        //    {
        //        // 抽取信息
        //        HttpWebRequest request = WebRequest.Create(aiUrl) as HttpWebRequest;
        //        request.Method = "POST";
        //        request.ContentLength = data.Length;
        //        request.ContentType = "application/json";
        //        using var input = request.GetRequestStream();
        //        input.Write(data, 0, data.Length);
        //        var resp = request.GetResponse() as HttpWebResponse;
        //        if (resp.StatusCode == HttpStatusCode.OK)
        //        {
        //            using var sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
        //            var respJson = sr.ReadToEnd();
        //            var respObj = JObject.Parse(respJson);
        //            var respText = respObj["response"].ToString();
        //            respText = respText.Substring(8).Replace("```", "");
        //            return respText;
        //        }
        //        else
        //        {
        //            throw new Exception(resp.StatusDescription);
        //        }
        //        // 内容摘要
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return string.Empty;
        //    }
        //}
    }
}
