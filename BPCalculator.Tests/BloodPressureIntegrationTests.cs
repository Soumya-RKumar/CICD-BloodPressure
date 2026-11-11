using BPCalculator;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BPCalculator.Tests;

public class BloodPressureIntegrationTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public BloodPressureIntegrationTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HomePage_ShouldReturnSuccessStatusCode()
    {
        // Arrange and Act
        var response = await _client.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task PrivacyPage_ShouldReturnSuccessStatusCode()
    {
        // Arrange and Act
        var response = await _client.GetAsync("/Privacy");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task ErrorPage_ShouldReturnSuccessStatusCode()
    {
        // Arrange and Act
        var response = await _client.GetAsync("/Error");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}