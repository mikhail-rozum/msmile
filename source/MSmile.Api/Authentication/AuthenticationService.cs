namespace MSmile.Api.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Services.Exceptions;

    /// <summary>
    /// Authentication service.
    /// </summary>
    public class AuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly JwtTokenConfiguration _configuration;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        /// <param name="userRepository">User repository.</param>
        public AuthenticationService(IOptions<JwtTokenConfiguration> configuration, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration.Value;
        }

        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="passwordHash">Password hash.</param>
        /// <returns>User model.</returns>
        public async Task<UserModel> Authenticate(string login, string passwordHash)
        {
            var user = await _userRepository
                .Get(x => 
                    x.Login.ToLower() == login.ToLower()
                    && x.PasswordHash == passwordHash)
                .Select(x => new
                    {
                        x.Id,
                        x.Login
                    })
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new BusinessException("Пользователь с указанным именем и паролем не найден");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
            };

            var identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, null);
            var token = CreateToken(identity.Claims);

            return new UserModel
            {
                Id = user.Id,
                Login = user.Login,
                Token = token
            };
        }

        /// <summary>
        /// Creates a JWT token.
        /// </summary>
        /// <param name="claims">Claims.</param>
        /// <returns>Token.</returns>
        private string CreateToken(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                _configuration.Issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_configuration.TokenLifetime), 
                signingCredentials: new SigningCredentials(_configuration.Secret.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
