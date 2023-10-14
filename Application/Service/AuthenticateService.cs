using Application.Service.Interface;
using Domain.Exceptions;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public AuthenticateService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;

        }
        public async Task<AuthenticatedResponse> Authenticateḍ(AuthenticatedRequest loginRequest)
        {
            var user = await _userRepository.FindByCondition(u => u.Email==loginRequest.Email).FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password,user.HashedPassword))
            {
                throw new AuthenticationException($"Email or passworld was incorrect");
            };

            var claimn = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7142",
                audience: "https://localhost:7142",
                claims: claimn,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return new AuthenticatedResponse(user, tokenString);
        }
    }
}
