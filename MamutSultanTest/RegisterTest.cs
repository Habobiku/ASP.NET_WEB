namespace MamutSultanTest;
using System.Transactions;
using MamutSultan.DAL.Models;
using MamutSultanTest.Helpers;


public class RegisterTests: BaseTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task BaseRegistration()
    {
        using(TransactionScope scope= Helper.CreateTransactionScope())
        {
            string email = Guid.NewGuid().ToString("N").Substring(0,5) + "@test.com";
            
            var validateEmail= await AuthBl.ValidateEmail(email);
            Assert.IsNull(validateEmail);
            
            int userId = await AuthBl.CreateUser(new UserModel()
            {
                Email=email,
                Password="Yuiiopas12"
            });
            Assert.Greater(userId,0);
            
            validateEmail= await AuthBl.ValidateEmail(email);
            Assert.IsNotNull(validateEmail);
        }
    }
}