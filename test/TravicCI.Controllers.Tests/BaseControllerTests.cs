using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Travis_CI.Api;
using TravisCI.Tests.Core;

namespace TravicCI.Controllers.Tests
{
    public class BaseControllerTests : BaseIntegrationTests
    {

        protected TestServer _server;
        protected HttpClient _client, _client2;

        public override void SetUp()
        {
            base.SetUp();
            _server = new TestServer(new WebHostBuilder()
               .UseEnvironment("Testing")
        .UseConfiguration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build()
    )

                .UseStartup<Startup>());

            _client = _server.CreateClient();
            _client.BaseAddress = new Uri("https://localhost");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        

            _client2 = _server.CreateClient();
            _client2.BaseAddress = new Uri("https://localhost");
            _client2.DefaultRequestHeaders.Accept.Clear();
            _client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        }

    }
}
