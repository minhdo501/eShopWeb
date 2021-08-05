using AuthenticationPlugin;
using EShopApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace EShopApi.Extensions
{
    public class ConfigureToken
    {
        public ObjectResult GenerateToken(LoginCredential loginCredential, IList<string> userRole, AuthService auth)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, loginCredential.Email),
                new Claim(ClaimTypes.Email, loginCredential.Email),
                new Claim(ClaimTypes.Role, userRole.Aggregate((i, j) => i + ","+ j))
            };

            var token = auth.GenerateAccessToken(claims);

            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
            });
        }
    }
}
