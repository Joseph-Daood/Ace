using Ace.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Text;

[TestClass]
public class FamiliesControllerIntegrationTests //: IDisposable
{

    private WebApplicationFactory<Program> _factory;//= new WebApplicationFactory<Program>();
    private HttpClient _client;//= _factory.CreateClient();

    [TestInitialize]
    public void Initialize()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }
    //public FamiliesControllerIntegrationTests()
    //{
    //    _factory = new WebApplicationFactory<Program>();
    //    _client = _factory.CreateClient();
    //}

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [TestMethod]
    public async Task GetAllFamilies_Returns_OK()
    {
        // Arrange: Customize the request if needed (e.g., add headers, query parameters).
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/families");

        // Act: Send the HTTP request.
        var response = await _client.SendAsync(request);

        // Assert: Check the response status code.
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task GetFamilyById_Returns_OK()
    {
        // Arrange: Customize the request if needed (e.g., add headers, query parameters).
        var familyId = 1; // Replace with a valid family ID.
        var request = new HttpRequestMessage(HttpMethod.Get, $"/api/families/{familyId}");

        // Act: Send the HTTP request.
        var response = await _client.SendAsync(request);

        // Assert: Check the response status code.
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task CreateNewFamily_Returns_Created()
    {
        // Arrange: Customize the request if needed (e.g., add headers).
        var familyCreateDto = new FamilyCreateDto
        {
            // Set properties for the new family.
        };
        var jsonContent = JsonConvert.SerializeObject(familyCreateDto);
        var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act: Send the HTTP request.
        var response = await _client.PostAsync("/api/families", requestContent);

        // Assert: Check the response status code and headers.
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.IsNotNull(response.Headers.Location);
    }

    [TestMethod]
    public async Task UpdateFamily_Returns_Created()
    {
        // Arrange: Customize the request if needed (e.g., add headers).
        var familyUpdateDto = new FamilyReadDto
        {
            // Set properties to update the family.
        };
        var jsonContent = JsonConvert.SerializeObject(familyUpdateDto);
        var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act: Send the HTTP request.
        var response = await _client.PutAsync("/api/families", requestContent);

        // Assert: Check the response status code and headers.
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.IsNotNull(response.Headers.Location);
    }

    [TestMethod]
    public async Task DeleteFamily_Returns_NoContent()
    {
        // Arrange: Customize the request if needed (e.g., add headers).
        var familyIdToDelete = 1; // Replace with a valid family ID.

        // Act: Send the HTTP request.
        var response = await _client.DeleteAsync($"/api/families/{familyIdToDelete}");

        // Assert: Check the response status code.
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    }
}
