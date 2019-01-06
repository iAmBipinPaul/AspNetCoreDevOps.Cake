using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using AspNetCoreDevOps.Tests.Core;
using AspNetCoreDevOps.Api;
namespace AspNetCoreDevOps.Controllers.Tests
{
    public class BaseControllerTests : BaseIntegrationTests
    {
        protected HttpClient Client, Client2;

        protected TestServer Server;

        public override void SetUp()
        {
            base.SetUp();
            Server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>());
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri("https://localhost");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
