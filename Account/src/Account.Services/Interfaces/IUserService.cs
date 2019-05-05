using Account.Domain.Entities;
using Account.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserToken> Authenticate(string username, string password);
    }
}
