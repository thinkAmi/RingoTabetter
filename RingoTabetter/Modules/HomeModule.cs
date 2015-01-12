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
        public string BaseUrl = @"https://ringo-tabetter-api.herokuapp.com/api/v1";


        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return View["total"];
            };


            Get["/month"] = _ =>
            {
                return View["month"];
            };
        }

        public Response RequestResource(string resource)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(resource, Method.GET);
            var result = client.Execute(request);
            var response = Response.AsText(result.Content);
            response.ContentType = "text/html; charset=utf8";

            return response;
        }
    }
}
