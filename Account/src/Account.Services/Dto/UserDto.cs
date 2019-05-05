using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Services.Dto
{
    public class UserToken
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }

}
