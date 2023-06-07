using System;
using MamutSultan.BL.Auth;
using MamutSultan.ViewMapper;
using MamutSultan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MamutSultan.Controllers;

public class RegisterController : Controller
{
    private readonly IAuthBL _authBl;

    public RegisterController(IAuthBL authBl)
    {
        _authBl = authBl;
    }

    [HttpGet]
    [Route("/register")]
    public IActionResult Index()
    {
        return View("Index", new RegisterViewModel());
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> IndexSave(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var errorModel= await _authBl.ValidateEmail(model.Email ?? "");
            if(errorModel!=null)
                ModelState.TryAddModelError("Email", errorModel.ErrorMessage!);
        }
        if (ModelState.IsValid)
        {            
            await _authBl.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
            return Redirect("/");
        }
        return View("Index", model);
    }
}