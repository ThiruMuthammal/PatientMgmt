using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PatientManagement.Services
{
    public class AuthService : IAuthService
    {

        public SymmetricSecurityKey SymmetricSecurityKey()
        {
            SymmetricSecurityKey Sign_Key = new(Encoding.UTF8.GetBytes("Jwt:Key:This is a sample secret key"));
            return Sign_Key;
        }
        public string GenerateJwtToken()
        {

            SigningCredentials signingCredentials = new SigningCredentials(SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            JwtHeader header = new JwtHeader(signingCredentials);

            DateTime expiry = DateTime.UtcNow.AddMinutes(10);
            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            JwtPayload payload = new JwtPayload
            {
                {"sub","patient" },
                {"Name","patientmanagement" },
                {"email","patientmanagement@gmail.com" },
                {"exp",ts },
                {"iss","https://localhost:7266" },
                {"aud","https://localhost:7266" },
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            string tokenSettings = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            Console.WriteLine(tokenSettings);
            Console.WriteLine("Consume Token");
            return tokenSettings;
        }
    }
}
