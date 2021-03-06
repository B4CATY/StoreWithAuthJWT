using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RefreshJWTToken.Models;
using RefreshJWTToken.Models.UserRoleModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RefreshJWTToken.Repository.JWT
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;

        public JWTManagerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Tokens GenerateRefreshToken(UserRefreshWithrRolesModel userAndRoleModel)
        {
            return GenerateJWTTokens(userAndRoleModel);
        }

		public string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		public Tokens GenerateToken(UserRefreshWithrRolesModel userAndRoleModel)
        {
            return GenerateJWTTokens(userAndRoleModel);
        }

		public Tokens GenerateJWTTokens(UserRefreshWithrRolesModel model)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
					{
						new Claim(ClaimTypes.Name, model.Email),
						//new Claim(ClaimTypes.Role, model.Role),
						new Claim("roles", model.Role)
					}),
					Expires = DateTime.Now.AddMinutes(10),//time of life acces token
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
				};

				

				var token = tokenHandler.CreateToken(tokenDescriptor);
				if(model.RefreshToken == null || model.RefreshToken.ValidityPeriod <= DateTime.Now)
                {
					var refreshToken = GenerateRefreshToken();
					return new Tokens { Access_Token = tokenHandler.WriteToken(token), Refresh_Token = refreshToken };
				}
				return new Tokens { Access_Token = tokenHandler.WriteToken(token), Refresh_Token = model.RefreshToken.RefreshToken };
			}
			catch (Exception)
			{
				return null;
			}
		}

		

		public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
			var Key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Key),
				ClockSkew = TimeSpan.Zero
			};

			var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
				var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
				JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
				if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				{
					throw new SecurityTokenException("Invalid token");
				}
				return principal;
			}
            catch (Exception)
            {
				return null;

			}
			


			
		}
    }
}
