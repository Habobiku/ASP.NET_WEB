
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using MamutSultan.DAL;
using MamutSultan.DAL.Models;

namespace MamutSultan.BL.Auth;

public class AuthBL : IAuthBL
{
    private readonly IAuthDAL _authDal;
    private readonly IEncrypt _encrypt;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthBL(IAuthDAL authDal,
        IEncrypt encrypt,
        IHttpContextAccessor httpContextAccessor)
    {
        _authDal = authDal;
        _encrypt = encrypt;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<int> CreateUser(UserModel user)
    {
        user.Salt = Guid.NewGuid().ToString();
        user.Password = _encrypt.HashPassword(user.Password, user.Salt);
        int id = await _authDal.CreateUser(user);
        Login(id);
        return id;
    }

    public async Task<int> Authenticate(string email, string password, bool rememberMe)
    {
        var user = await _authDal.GetUser(email);
        
        if (user.UserId != null && user.Password == _encrypt.HashPassword(password, user.Salt))
        {
            Login(user.UserId ?? 0);
            return user.UserId ?? 0;
        }
        
        throw new AuthenticationException("qwe");
    }

    public void Login(int id)
    {
        _httpContextAccessor.HttpContext?.Session.SetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME, id);
    }

    public async Task<ValidationResult?> ValidateEmail(string email)
    { 
        var user = await _authDal.GetUser(email);
        if (user.UserId != null)
            return new ValidationResult("This email is already exists");
        return null;
    }
}