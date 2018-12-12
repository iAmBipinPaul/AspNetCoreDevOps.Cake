using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using AspNetCoreDevOps.Api.Models;

namespace AspNetCoreDevOps.Controllers.Tests.IntegrationTests
{
    [TestFixture]
    internal class HomeControllerTests : BaseControllerTests
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [Test]
        public async Task GetPeopleSuccessfullyAsync()
        {
            var response = await Client.GetAsync("Home/index");
            var people = new List<Person>();
            Assert.That(response.IsSuccessStatusCode, Is.EqualTo(true));
            if (response.IsSuccessStatusCode)
            {
                var af = await response.Content.ReadAsStringAsync();
                people = JsonConvert.DeserializeObject<List<Person>>(af);
            }

            Assert.That(people.Count, Is.EqualTo(1000));
        }
    }
}