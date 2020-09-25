using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using Models;
using VehicleMaintenceService.API.IntegrationTests.Helpers;
using VehicleMaintenceService;

namespace VehicleMaintenceService.API.IntegrationTests
{
    [TestFixture]
    public class TemplateControllerTests 
    {
        [Test]
        public async Task GetRequest()
        {
            // Arrange
            var request = new
            {
                Url = "/api/template",
                Content = new object { }
            };

            // Act
           // var response = await PostAsync(request.Url, request.Content);
            //var value = await response.Content.ReadAsStringAsync();

            // Assert
          //  Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, value);
        }

    }
}
