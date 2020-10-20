using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticateApi.LoginModel;
using AuthenticateApi.Models;
using AuthenticateApi.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _config;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));

        public AuthController(IRepository repository,IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        /// <summary>
        /// Returns details of the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>User</returns>

        [HttpGet("{username}")]
        public IActionResult GetDetail(string username)
        {
            try
            {
                _log4net.Info(nameof(GetDetail) + " method invoked");
                var user = _repository.GetUserDetails(username);
                return Ok(user);
            }
            catch(Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(GetDetail) + "Error Message : " + e.Message);
                return NotFound();
            }
            
        }

        /// <summary>
        /// 1. Checking if the user credentials are valid.
        /// 2. If Valid then genreate JWT token.
        /// 3. Else return Unauthorized
        /// </summary>
        /// <param name="login"></param>
        /// <returns>response</returns>

        [HttpPost("Login")]
        public IActionResult Login(UserLogin login)
        {
            try
            {
                _log4net.Info(nameof(Login)+" meyhod invoked");
                IActionResult response = Unauthorized();
                var user = _repository.GetUser(login);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                }
                return response;
            }
            catch(Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(Login) + "Error Message : " + e.Message);
                return Ok(StatusCodes.Status401Unauthorized);
            }
            
        }


       
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var expiry = DateTime.Now.AddMinutes(double.Parse(_config["Jwt:AccessExpireMinutes"]));

            List<Claim> claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            //claims.Add(new Claim(ClaimTypes.Role, userInfo.Username));
            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      

        
    }
}
