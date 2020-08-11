using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Web.Operations
{
    public class ConsumeApi
    {
        public dynamic ConsumeApiService(Type type, string url, string objRequest, Method method)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            if (string.IsNullOrEmpty(objRequest))
            {
                objRequest = "";
            }
            var client = new RestClient(url);
            client.Encoding = Encoding.UTF8;
            var request = new RestRequest();
            request.Method = method;

            if (method == Method.GET)
                request.AddParameter("application/json", "", ParameterType.RequestBody);
            else
            {
                var body = request.AddJsonBody(objRequest);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject(response.Content, type);
        }
    }
}