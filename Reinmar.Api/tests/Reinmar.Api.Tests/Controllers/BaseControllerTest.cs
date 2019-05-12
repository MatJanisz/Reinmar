using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Reinmar.Api.Tests.Controllers
{
    [TestFixture]
    public class BaseControllerTest
    {
        protected TestServer _server;
        protected HttpClient _testClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _testClient = _server.CreateClient();
        }
    }
}