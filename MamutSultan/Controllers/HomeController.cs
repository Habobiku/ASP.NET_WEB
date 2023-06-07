using System.Diagnostics;
using MamutSultan.BL.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MamutSultan.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICurrentUser _currentUser;

    public HomeController(ILogger<HomeController> logger, ICurrentUser currentUser)
    {
        this._logger = logger;
        this._currentUser = currentUser;
    }

    public IActionResult Index()
    {
        return View(_currentUser.IsLoggedIn());
    }

    public IActionResult Privacy()
    {
        return View();
    }
}

