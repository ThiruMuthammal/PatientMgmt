using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PatientManagement.Services;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult GetJwtToken()
        {
            string getJwtToken = _authService.GenerateJwtToken();
            if (!getJwtToken.IsNullOrEmpty())
            {
                return Ok(getJwtToken);
            }
            return BadRequest();
        }
    }
}
