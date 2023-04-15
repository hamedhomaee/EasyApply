using EasyApplyWebSolution.IntegrationTests.Helpers;
using Fizzler.Systems.HtmlAgilityPack;
using FluentAssertions;
using HtmlAgilityPack;

namespace EasyApplyWebSolution.IntegrationTests;

public class AccountControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    // Private fields
    private readonly HttpClient _httpClient;

    // Class Constructor
    public AccountControllerIntegrationTests(CustomWebApplicationFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    // Tests
    #region Login_HTMLDocumentContainsThreeH3TagsForAuthProviders
        [Fact]
        public async Task Login_HTMLDocumentContainsThreeH3TagsForAuthProviders()
        {
            // Sending GET request to account/login
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("account/login");

            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            
            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(responseBody);

            var htmlNodes = htmlDocument.DocumentNode;

            IEnumerable<HtmlNode> h3Tags = htmlNodes.QuerySelectorAll("h3");
            
            // Assert
            h3Tags.Count().Should().Be(3);
        }
    #endregion
}