using MamutSultan.BL.Auth;
using MamutSultan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MamutSultan.Controllers;

public class ProfileController:Controller
{
    private readonly IAuthBL _authBl;

    public ProfileController(IAuthBL authBl)
    {
        this._authBl = authBl;
    }

    [HttpGet]
    [Route("/profile")]
    public IActionResult Index()
    {
        return View(new ProfileViewModel());
    }

    [HttpPost]
    [Route("/profile")]
    public IActionResult IndexSave()
    {
       return View("Index", new ProfileViewModel());
    }
}