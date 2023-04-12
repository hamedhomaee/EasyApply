using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyApplyWebSolution.Controllers;

public class HomeController : Controller
{
    // [AllowAnonymous]
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}