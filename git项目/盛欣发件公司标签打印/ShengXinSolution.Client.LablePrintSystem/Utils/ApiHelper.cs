using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystem.Utils
{
    public class ApiHelper
    {
        public static string baseUrl =

             Properties.Settings.Default.API_SERVER_HOST 
            + ":"
            + Properties.Settings.Default.API_SERVER_PORT;

        public static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static object DeserializeJson(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        public static string ExecuteApi(string url, Method method, Dictionary<string, object> urlParameters, Dictionary<string, object> urlSegments)
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest();

            request.Method = method;
            request.Resource = url;
            client.Timeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT; ;
            request.ReadWriteTimeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;

            if (urlParameters != null && urlParameters.Count > 0)
            {
                foreach (var item in urlParameters)
                {
                    request.AddParameter(item.Key, item.Value);
                }
            }
            if (urlSegments != null && urlSegments.Count > 0)
            {
                foreach (var item in urlSegments)
                {
                    request.AddUrlSegment(item.Key, item.Value.ToString());
                }
            }
            var response = client.Execute(request);
            return response.Content;
            throw new Exception(response.Content);
        }

        public static string ExecuteApi(string url, Method method, object entity)
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest();

            request.Method = method;
            request.Resource = url;
            client.Timeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;
            request.ReadWriteTimeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;

            request.AddJsonBody(entity);
            var response = client.Execute(request);
            return response.Content;
            throw new Exception(response.Content);
        }


        public static string Get(string url, Dictionary<string, object> urlParameters, Dictionary<string, object> urlSegments)
        {
            return ExecuteApi(url, Method.GET, urlParameters, urlSegments);
        }

        public static string Get(string url, object entity)
        {
            return ExecuteApi(url, Method.GET, entity);
        }

        public static string Post(string url, Dictionary<string, object> param)
        {
            return ExecuteApi(url, Method.POST, param, null);
        }

        public static string Post(string url, object entity)
        {
            return ExecuteApi(url, Method.POST, entity);
        }

        public static string Put(string url, Dictionary<string, object> param)
        {
            return ExecuteApi(url, Method.PUT, param, null);
        }

        public static string Put(string url, object entity)
        {
            return ExecuteApi(url, Method.PUT, entity);
        }

        public static string Delete(string url, Dictionary<string, object> param)
        {
            return ExecuteApi(url, Method.DELETE, param, null);
        }

        public static string Delete(string url, object entity)
        {
            return ExecuteApi(url, Method.DELETE, entity);
        }

        //public static string FileUp(string url, System.IO.Stream stream, string fileName)
        //{
        //    request.Resource = url;
        //    request.Method = Method.POST;
        //    request.AlwaysMultipartFormData = true;
        //    AddHeader(request, access_token);
        //    //  request.AddHeader("guid", Guid.NewGuid().ToString());
        //    request.AddFile("file", ReadToEnd(stream), HttpContext.Current.Server.HtmlEncode(fileName));
        //    var posttask = client.ExecutePostTaskAsync(request);
        //    if (posttask.Result.StatusCode == HttpStatusCode.OK)
        //    {
        //        return posttask.Result.Content;
        //    }
        //    else
        //    {
        //        throw new WebException(posttask.Result.Content);
        //    }

        //}
        //private static byte[] ReadToEnd(System.IO.Stream stream)
        //{
        //    long originalPosition = stream.Position;
        //    stream.Position = 0;

        //    try
        //    {
        //        byte[] readBuffer = new byte[4096];

        //        int totalBytesRead = 0;
        //        int bytesRead;

        //        while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
        //        {
        //            totalBytesRead += bytesRead;

        //            if (totalBytesRead == readBuffer.Length)
        //            {
        //                int nextByte = stream.ReadByte();
        //                if (nextByte != -1)
        //                {
        //                    byte[] temp = new byte[readBuffer.Length * 2];
        //                    Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
        //                    Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
        //                    readBuffer = temp;
        //                    totalBytesRead++;
        //                }
        //            }
        //        }

        //        byte[] buffer = readBuffer;
        //        if (readBuffer.Length != totalBytesRead)
        //        {
        //            buffer = new byte[totalBytesRead];
        //            Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
        //        }
        //        return buffer;
        //    }
        //    finally
        //    {
        //        stream.Position = originalPosition;
        //    }
        //}
        private static void AddToken(RestRequest request, string access_token)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            if (!string.IsNullOrEmpty(access_token))
            {
                request.AddHeader("Authorization", "Bearer " + access_token);
            }
        }

        private static void AddCookies(RestRequest request, string cookies)
        {
           
        }
    }
}

