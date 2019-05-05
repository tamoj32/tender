using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<bool> CheckPasswordAsync(string username, string password);

        Task<User> GetUserAsync(string username, string password);
    }
}
