using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ReservationSystem.API.Helpers.Hashing;
using ReservationSystem.API.Services.MasterService.Interface;
using ReservationSystem.API.Services.UserService.Interfaces;
using ReservationSystem.API.Models.Requests.Authentication;
using ReservationSystem.API.Models.Responses.Authentication;

namespace ReservationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGetUserService _getUserService;
        private readonly IGetMasterService _getMasterService;

        public AuthController(IConfiguration configuration, IGetUserService getUserService, IGetMasterService getMasterService)
        {
            _configuration = configuration;
            _getUserService = getUserService;
            _getMasterService = getMasterService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _getUserService.GetUserByEmail(request.Username ?? "");
                if (user != null)
                {
                    if (!HashingPassword.VerifyPassword(request.Password ?? "", user.EncryptedPassword, user.GeneratedSalt))
                    {
                        return Unauthorized();
                    }

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.Description),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? ""));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddMinutes(30),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new LoginResponse("S01")
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                    });
                }

                return Unauthorized();
            }
            catch (Exception)
            {
                return Unauthorized();
                throw;
            }
        }
    }
}
