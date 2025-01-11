using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.Millon.API.Models.Utility;

namespace Test.Millon.API.Services
{
    public class AuthenticationMillon : IAuthenticationMillon
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationMillon(IOptions<JwtSettings> jwtSetting)
        {
            _jwtSettings = jwtSetting.Value;
        }

        /// <summary>
        /// Este metodo se encarga de crear el token de session simulando un incio de session previo 
        /// para el uso del API
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>token en formato bearer</returns>
        public string LoginAsync(string user, string password)
        {
            string tokenString = string.Empty;
            if (user.Equals(MillonConstans.User) && password.Equals(MillonConstans.Password)) // validacion basica
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(MillonConstans.LimitToken),
                    Issuer = _jwtSettings.Issuer, //Estos parametros se deben de obtener de un archivo de configuracion
                    Audience = _jwtSettings.Audience, //Pero se dejan asi por simplicidad, ya que es mas seguro desde un keyvault de azure
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenString = MillonConstans.SchemaToken + tokenHandler.WriteToken(token);
            }

            return tokenString;
        }
    }
}
