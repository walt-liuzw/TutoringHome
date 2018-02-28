﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TutoringHome.Web.CommonHelper
{
    public static class HttpClientHelper
    {
        private static HttpClient Client;
        static HttpClientHelper()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.
                Add(new MediaTypeWithQualityHeaderValue("application/json")
                { CharSet = "utf-8" });
        }
        public static string HttpGet(string url)
        {
            var responseMsg = Client.GetAsync(url).Result;
            var responseContent = responseMsg.Content.ReadAsStringAsync().Result;
            if (responseMsg.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException(string.Format("调用{0}接口出错！StatusCode：{1}，Msg：{2}",
                    url, responseMsg.StatusCode, responseContent));
            }
            return responseContent;
        }
        public static string HttpPost(string url, object data)
        {
            var content = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseMsg = Client.PostAsync(url, httpContent).Result;
            var responseContent = responseMsg.Content.ReadAsStringAsync().Result;
            if (responseMsg.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException(string.Format("调用{0}接口出错！StatusCode：{1}，Msg：{2}",
                    url, responseMsg.StatusCode, content));
            }
            return responseContent;
        }
        public static string HttpPut(string url, object data)
        {
            var content = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseMsg = Client.PutAsync(url, httpContent).Result;
            var responseContent = responseMsg.Content.ReadAsStringAsync().Result;
            if (responseMsg.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException(string.Format("调用{0}接口出错！StatusCode：{1}，Msg：{2}",
                    url, responseMsg.StatusCode, content));
            }
            return responseContent;
        }
        public static string HttpDelete(string url)
        {
            var responseMsg = Client.DeleteAsync(url).Result;
            var responseContent = responseMsg.Content.ReadAsStringAsync().Result;
            if (responseMsg.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException(string.Format("调用{0}接口出错！StatusCode：{1}，Msg：{2}",
                    url, responseMsg.StatusCode, responseContent));
            }
            return responseContent;
        }

    }
}