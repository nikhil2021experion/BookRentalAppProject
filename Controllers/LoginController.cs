using BookRentalAppProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //1 dependency injection for configuration
        private readonly IConfiguration _config;

        //2 constructor injection
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        //3 HTTpPost method
        [HttpPost("token")]
        public IActionResult Login([FromBody] UserModel user)
        {
            //checking unauthorized
            IActionResult response = Unauthorized();

            //authenticate the user
            var loginUser = AuthenticateUser(user);

            //validate the user and generate the token
            if (loginUser != null)
            {
                //
                var tokenString = GenerateJWTToken(loginUser);
                response = Ok(new { token = tokenString });
            }

            //return Ok("Hello From API");
            return response;
        }




        //4 authenticate user method
        private UserModel AuthenticateUser(UserModel user)
        {
            UserModel loginUser = null;

            //validate the credentials
            //retrieve data from the database
            if (user.UserName == "nikhil")
            {
                loginUser = new UserModel
                {
                    UserName = "nikhil",
                    Password = "nik123",
                    EmailAddress = "nik@gmail.com",
                    DateOfJoining = new DateTime(2020, 12, 10),
                    Role = "administrator"
                };
            }
            return loginUser;
            //throw new NotImplementedException();
        }

        //5 generate token
        private string GenerateJWTToken(UserModel loginUser)
        {
            //security key 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //signing credential 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //client  --roles

            //generate  token
            var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],      //header
                    _config["Jwt:Issuer"],      //payload
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
            //throw new NotImplementedException();
        }
    }
}
