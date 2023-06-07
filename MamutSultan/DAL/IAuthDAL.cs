using MamutSultan.DAL.Models;

namespace MamutSultan.DAL;

public interface IAuthDAL
{
    public Task<UserModel> GetUser(string email);
    public Task<UserModel> GetUser(int id);
    public Task<int> CreateUser(UserModel user);
}