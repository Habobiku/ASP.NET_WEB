using MamutSultan.BL.Auth;
using MamutSultan.DAL;
using Microsoft.AspNetCore.Http;

namespace MamutSultanTest.Helpers;

public class BaseTest
{
    protected readonly IAuthDAL AuthDal = new AuthDAL();
    protected readonly IEncrypt Encrypt = new Encrypt();
    protected readonly IHttpContextAccessor HttpContextAccessor = new HttpContextAccessor();
    protected IAuthBL AuthBl;

    public BaseTest()
    {
        AuthBl= new AuthBL(AuthDal, Encrypt, HttpContextAccessor);
    }
}