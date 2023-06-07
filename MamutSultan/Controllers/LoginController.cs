using System.Security.Authentication;
using MamutSultan.BL.Auth;
using MamutSultan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MamutSultan.Controllers;

public class LoginController:Controller
{
    private readonly IAuthBL _authBl;
    
    public LoginController(IAuthBL authBl)
    {
        this._authBl = authBl;
    }
    
    [HttpGet]
    [Route("/login")]
    public IActionResult Index()
    {
        return View("Index", new LoginViewModel());
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> IndexSave(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _authBl.Authenticate(model.Email!, model.Password!,model.RememberMe==true);
                return Redirect("/");
            }
            catch (AuthenticationException)
            {
              ModelState.AddModelError("Email", "Name or Email not found");
            }
           
        }

        return View("Index", model);
    }
}