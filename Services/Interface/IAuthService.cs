using Microsoft.IdentityModel.Tokens;

namespace PatientManagement
{
    public interface IAuthService
    {
        string GenerateJwtToken();
        SymmetricSecurityKey SymmetricSecurityKey();
    }
}