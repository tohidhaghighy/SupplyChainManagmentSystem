using Newtonsoft.Json;
using RestSharp;

namespace Schm.UI.Infrastructure.Common
{
    public static class SendRequest<T>
    {
        public static ResponseBody<T> Send(string url, Method method, string body, bool haveBody = true)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            if (haveBody)
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return new ResponseBody<T>
                {
                    Result = JsonConvert.DeserializeObject<T>(response.Content),
                    IsSuccess = true,
                };
            }
            else
            {
                return new ResponseBody<T>
                {
                    Result = JsonConvert.DeserializeObject<T>(response.Content),
                    IsSuccess = false,
                };
            }
        }
    }
}
