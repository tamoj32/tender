using Account.Domain.Entities;
using Account.Domain.IRepository;
using Account.Services.Dto;
using Account.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Implementaions
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenProviderOptions _options;

        public UserService(IUserRepository userRepository, IOptions<TokenProviderOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        public async Task<UserToken> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserAsync(username, password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var now = DateTime.UtcNow;

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Sid, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT and write it to a string
            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims.ToArray(),
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            var userToken = new UserToken();
            userToken.AccessToken = encodedJwt;
            userToken.ExpiresIn = (int)_options.Expiration.TotalSeconds;

            return userToken;
        }

        /// <summary>
        /// Get this date time as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date)
            .ToUniversalTime().ToUnixTimeSeconds();

    }
}
