using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL.Migrations;
using AngularWebAPIProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularWebAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly IAccount account;
        private readonly IConfiguration configuration;
        public AccountAPIController(IAccount account, IConfiguration configuration)
        {
            this.account = account;
            this.configuration = configuration;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                LoginResponseModel loginResponseModel = new();
                loginResponseModel = account.Login(loginModel);
                List<RoleModel> roles = new List<RoleModel>();
                roles = account.GetRole();
                if (loginResponseModel != null)
                {
                    if (!string.IsNullOrEmpty(loginResponseModel.UserName))
                    {
                        var authClaims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, loginResponseModel.UserName),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            };
                        foreach (var userRole in roles)
                        {
                            if (!string.IsNullOrEmpty(userRole.RoleName))
                            {
                                authClaims.Add(new Claim(ClaimTypes.Role, userRole.RoleName));
                            }
                        }

                        var secret = configuration["JWT:Secret"];
                        if (!string.IsNullOrEmpty(secret))
                        {
                            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
                            var token = new JwtSecurityToken(
                                issuer: configuration["JWT:ValidIssuer"],
                                audience: configuration["JWT:ValidAudience"],
                                expires: DateTime.Now.AddHours(3),
                                claims: authClaims,
                                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                                );
                            loginResponseModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
                            loginResponseModel.ExpiryTime = token.ValidTo;
                        }
                    }
                }
                return Ok(loginResponseModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
