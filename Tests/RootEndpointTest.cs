using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace Tests;

public class RootEndpointTest : IClassFixture<Program>
{
    [Fact]
    public async Task GetShouldReturnHelloWorld()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetAsync("/api/v1/");
        var result = await response.Content.ReadFromJsonAsync<Response>();

        Assert.Equal("Hello World!", result?.Message);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private class Response
    {
        public string Message { get; set; }
    }
}