using Dapper;
using MamutSultan.DAL.Models;
using MySql.Data.MySqlClient;

namespace MamutSultan.DAL;

public class AuthDAL : IAuthDAL
{
    public async Task<UserModel> GetUser(string email)
    {
        using (var conn = new MySqlConnection(DBHelper.ConnString))
        {
            await conn.OpenAsync();
            return await conn.QueryFirstOrDefaultAsync<UserModel>(@"
                select UserId, Email, Password, Salt, Status
                from AppUser
                where Email=@email", new { email = email }) ?? new UserModel();
        }
    }

    public async Task<UserModel> GetUser(int id)
    {
        using (var conn = new MySqlConnection(DBHelper.ConnString))
        {
            await conn.OpenAsync();
            return await conn.QueryFirstOrDefaultAsync<UserModel>(@"
                select UserId, Email, Password, Salt, Status
                from AppUser
                where Id=@id", new { id = id }) ?? new UserModel();
        }
    }

    public async Task<int> CreateUser(UserModel user)
    {
        using (var conn = new MySqlConnection(DBHelper.ConnString))
        {
            await conn.OpenAsync();
            string querySQL = @"insert into AppUser(Email, Password, Salt, Status) 
                values(@Email, @Password, @Salt, @Status);
                 SELECT LAST_INSERT_ID();";

            return await conn.QuerySingleAsync<int>(querySQL, user);
        }
    }
}