using NumbersApp;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using NumbersApp.Models;

namespace Tests.NumbersApp.Tests
{
    [TestFixture]
    [Category("IntegrationTests")]
    public class HomeControllerTests
    {
        private WebApplicationFactory<Startup> _appFactory => new WebApplicationFactory<Startup>();
        private HttpClient _client;
        public HomeControllerTests()
        {
            _client = _appFactory.CreateClient();
        }

        [Test]
        public async Task Add_SuccessCode()
        {
            string url = "http://localhost:8000/Home/Add";
            var result = await _client.GetAsync(url);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [Test]
        public async Task Sum_SuccessCode()
        {
            // Arrange
            string url = "http://localhost:8000/Home/Sum";

            List<NumberDto> numbers = new List<NumberDto>() { new NumberDto { Id = 1, Value = 100 }, new NumberDto { Id = 2, Value = 200 } };
            string jsnoString = JsonConvert.SerializeObject(numbers);
            HttpContent content = new StringContent(jsnoString, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage result = await _client.PostAsync(url, content);
            string jresult = await result.Content.ReadAsStringAsync();
            var numbersResult = JsonConvert.DeserializeObject<long>(jresult);

            // Assert
            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.AreEqual(300, numbersResult);
        }

    }
}