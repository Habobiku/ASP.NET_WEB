using MamutSultan.DAL.Models;
using MamutSultan.ViewModels;

namespace MamutSultan.ViewMapper;

public class AuthMapper
{
    public static UserModel MapRegisterViewModelToUserModel(RegisterViewModel model)
    {
        return new UserModel()
        {
            Email = model.Email!,
            Password = model.Password!
        };
    }
}