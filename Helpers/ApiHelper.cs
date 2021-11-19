using System.Collections.Generic;
using System.Net;
using Tests.Models;
using FluentAssertions;
using RestSharp;

namespace Tests.Helpers
{
    public class ApiHelper
    {
        public RestClient Client {get ; private set;}

        public ApiHelper()
        {
            Client = new RestClient();
        }

        public List<LogicalServer> GetVPNServerResponse() 
        {
            Client.BaseUrl = new System.Uri("https://api.protonmail.ch/vpn/logicals");

            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "api.protonmail.ch");
            request.AddHeader("Postman-Token", "940920c7-7d32-4b3a-b60c-90846b022a37,c060e700-5caa-4772-8c73-3d2f7b30c089");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");

            var response = Client.Execute<VPNLogicalsModel>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK, "response should be returned correctly");

            return response.Data.LogicalServers;
        }
    }
}