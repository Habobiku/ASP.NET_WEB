using System.ComponentModel.DataAnnotations;
using MamutSultan.DAL.Models;

namespace MamutSultan.BL.Auth;

public interface IAuthBL
{
    public Task<int> CreateUser(UserModel user);
    public Task<int> Authenticate(string email, string password, bool rememberMe);
    public Task<ValidationResult?> ValidateEmail(string email);
        
}