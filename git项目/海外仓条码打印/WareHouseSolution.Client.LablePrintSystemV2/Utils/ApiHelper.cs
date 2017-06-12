using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace WareHouseSolution.Client.LablePrintSystem.Utils
{
    class ApiHelper
    {
        public static string BaseUrl =
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
            var client = new RestClient(BaseUrl);
            var request = new RestRequest
            {
                Method = method,
                Resource = url
            };

            client.Timeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;
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

            AddToken(request);

            var response = client.Execute(request);
            return response.Content;
        }

        public static string ExecuteApi(string url, Method method, object entity)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest();

            request.Method = method;
            request.Resource = url;
            client.Timeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;
            request.ReadWriteTimeout = Properties.Settings.Default.HTTP_REQUEST_TIMEOUT;

            request.AddJsonBody(entity);

            AddToken(request);
            var response = client.Execute(request);
            return response.Content;
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

        private static void AddToken(RestRequest request)
        {
            string access_token = Properties.Settings.Default.ACCESS_TOKEN;

            if (string.IsNullOrEmpty(access_token))
            {
                MainFrm.ActiveForm.Close();
                new MainFrm().ShowDialog();
            }
            access_token = Properties.Settings.Default.ACCESS_TOKEN;
            request.AddHeader("access-token", access_token);
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

        }
    }
}
