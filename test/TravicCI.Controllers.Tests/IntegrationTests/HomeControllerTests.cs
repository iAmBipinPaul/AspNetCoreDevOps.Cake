using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Travis_CI.Api.Models;

namespace TravicCI.Controllers.Tests.IntegrationTests
{

    [TestFixture]
    class HomeControllerTests : BaseControllerTests
    {
        

        [SetUp]
        public override void SetUp()
        {

            base.SetUp();
           
        }
         
        [Test]
        public async Task GetPeopleSuccessfullyAsync()
        {           
            HttpResponseMessage response = await _client.GetAsync($"Home/index");
            var people = new List<Person>();
            Assert.That(response.IsSuccessStatusCode, Is.EqualTo(true));
            if (response.IsSuccessStatusCode)
            {
                var af = await response.Content.ReadAsStringAsync();
                people = JsonConvert.DeserializeObject<List<Person>>(af);
            }
            Assert.That(people.Count,Is.EqualTo(1000));
        }
    }
}