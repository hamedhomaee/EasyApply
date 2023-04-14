using EasyApplyWebSolution.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyApplyWebSolution.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    [AllowAnonymous]
    [Route("account/login")]
    public async Task<IActionResult> LoginAsync()
    {
        ViewBag.AuthProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();

        return View();
    }
}