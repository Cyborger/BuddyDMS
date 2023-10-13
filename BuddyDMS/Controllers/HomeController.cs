using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BuddyDMS.Models;
using Microsoft.AspNetCore.Identity;

namespace BuddyDMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private SignInManager<IdentityUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        if (_signInManager.IsSignedIn(User))
            return View("Dashboard");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}