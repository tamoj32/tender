using Account.Domain.Entities;
using Account.Domain.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbManager _dbManager;

        public UserRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task<bool> CheckPasswordAsync(string username, string password)
        {
            int id = await _dbManager.Connection.ExecuteScalarAsync<int>("Select id from Users where username = @username and password = @password;", new { username, password });
            return id > 0;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await _dbManager.Connection.QuerySingleOrDefaultAsync<User>("Select * from users where username = @username and password = @password;", new { username, password });
        }
    }
}
