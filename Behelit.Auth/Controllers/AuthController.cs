using Behelit.Data.Entities;
using Behelit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Behelit.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IConfiguration Configuration { get; }


        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            Configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt.IssuerSigningKey")));

                var token = new JwtSecurityToken(
                    issuer: Configuration.GetValue<string>("Jwt.ValidIssuer"),
                    audience: Configuration.GetValue<string>("Jwt.ValidAudience"),
                    expires: DateTime.Now.AddDays(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                var data = new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };

                var cookieOptions = new CookieOptions
                {
                    // Secure = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Domain = Configuration.GetValue<string>("CookieDomain"),
                    Expires = DateTime.Now.AddDays(10)
                };

                HttpContext.Response.Cookies.Append("X-Access-Token", JsonSerializer.Serialize(data), cookieOptions);

                return Ok();
            }

            return Unauthorized();
        }
    }
}
