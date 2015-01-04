using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nancy;
using RestSharp;

namespace RingoTabetter.Modules
{
    public class HomeModule : NancyModule
    {
        public string BaseLocalUrl = @"http://localhost:9876";


        public HomeModule()
        {
            Get["/"] = _ => "Hello World";

            Get["/total"] = _ =>
            {
                var response = RequestResource("total");
                return response;
            };

            Get["/month"] = _ =>
            {
                var response = RequestResource("month");
                return response;
            };
        }

        public Response RequestResource(string resource)
        {
            var client = new RestClient(BaseLocalUrl);
            var request = new RestRequest(resource, Method.GET);
            var result = client.Execute(request);
            var response = Response.AsText(result.Content);
            response.ContentType = "text/html; charset=utf8";

            return response;
        }
    }
}
