using AntiToDo.Security.Common.Interfaces;
using AntiToDo.Security.Common.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AntiToDo.Security.Common.Services
{
    public class TokenProviderService : ITokenProviderService
    {
        private readonly TokenProviderOptions _options;
        public TokenProviderService(IOptions<TokenProviderOptions> options)
        {
            _options = options.Value;
        }
        public object GenerateToken(string userEmail, IEnumerable<string> roles, string userId)
        {
            IEnumerable<Claim> claims = CreateClaims(userEmail, roles, userId);

            byte[] tokenKey = Convert.FromBase64String(_options.Secret);

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audiences.First(),
                claims: claims,
                expires: DateTime.UtcNow.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new
            {
                access_token = token,
                expires_in = (int)_options.Expiration.TotalSeconds
            };
        }

        public string GenerateRefreshToken(string userId)
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal ExtractClaims(string encodedString)
        {
            byte[] tokenKey = Convert.FromBase64String(_options.Secret);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidAudiences = _options.Audiences,
                ValidIssuer = _options.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            return new JwtSecurityTokenHandler().ValidateToken(encodedString, tokenValidationParameters, out validatedToken);
        }

        private IEnumerable<Claim> CreateRoleClaims(IEnumerable<string> roles)
        {
            List<Claim> roleClaims = new List<Claim>();
            foreach (string role in roles)
            {
                Claim newRoleClaim = new Claim(ClaimTypes.Role, role);
                roleClaims.Add(newRoleClaim);
            }

            return roleClaims;
        }

        private IEnumerable<Claim> CreateClaims(string userEmail, IEnumerable<string> roles, string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userEmail),
                new Claim(ClaimTypes.Name, userId)
            };

            List<Claim> roleClaims = CreateRoleClaims(roles).ToList();

            claims.AddRange(roleClaims);

            return claims;
        }
    }
}
