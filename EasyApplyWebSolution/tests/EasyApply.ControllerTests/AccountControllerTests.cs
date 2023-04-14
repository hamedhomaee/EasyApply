using EasyApplyWebSolution.Controllers;
using EasyApplyWebSolution.ControllerTests.Helpers;
using EasyApplyWebSolution.Core.Domain.IdentityEntities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

namespace EasyApplyWebSolution.ControllerTests;

public class AccountControllerTests
{
    // Test class fields
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly SignInManager<ApplicationUser> _signInManager;

    // Test class constructor
    public AccountControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _signInManager = new FakeSignInManager();
    }

    #region LoginPage_ReturnsViewResult
    [Fact]
    public async Task LoginPage_ReturnsViewResult()
    {
        // Arrange
        // Creating an instance of the AccountController
        AccountController accountController = new AccountController(_signInManager);

        // Act
        var result = await accountController.LoginAsync();

        // Assert
        _testOutputHelper.WriteLine($"The result data type is {result.GetType()}");
        result.Should().BeOfType<ViewResult>();
    }
    #endregion
}