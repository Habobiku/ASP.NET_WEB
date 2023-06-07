namespace MamutSultan.BL.Auth;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsLoggedIn()
    {
        int? id = _httpContextAccessor.HttpContext?.Session.GetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME);
        return id != null;
    }
}